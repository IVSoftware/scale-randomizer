using Equin.ApplicationFramework;
using System.ComponentModel;
using System.Globalization;
using static System.Net.WebRequestMethods;

namespace scale_randomizer
{
    public partial class MainForm : Form
    {
        public MainForm() => InitializeComponent();

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Scales.Add(new Scale
            {
                Key = Key.C,
                Notes = new[] { "C", "D", "E", "F", "G", "A", "B", "C", },
            });
            Scales.Add(new Scale
            {
                Key = Key.D,
                Notes = new[] 
                { 
                    "D", "E", 
                    $"F{Signature.Sharp.ToUnicode()}", 
                    "G", "A", "B", 
                    $"C{Signature.Sharp.ToUnicode()}", 
                    "D", 
                },
            });
            Scales.Add(new Scale
            {
                Key = Key.E,
                Notes = new[] 
                { 
                    "E", 
                    $"F{Signature.Sharp.ToUnicode()}", 
                    $"G{Signature.Sharp.ToUnicode()}", 
                    "A", "B", 
                    $"C{Signature.Sharp.ToUnicode()}", 
                    $"D{Signature.Sharp.ToUnicode()}", 
                    "E", 
                },
            });
            Scales.Add(new Scale
            {
                Key = Key.F,
                Notes = new[] 
                { 
                    "F", "G", "A", 
                    $"B{Signature.Flat.ToUnicode()}", 
                    "C", "D", "E", "F",
                },
            });
            Scales.Add(new Scale
            {
                Key = Key.G,
                Notes = new[] 
                { 
                    "G", "A", "B", "C", "D", "E", 
                    $"F{Signature.Sharp.ToUnicode()}", 
                    "G", 
                },
            });
            Scales.Add(new Scale
            {
                Key = Key.B, Signature = Signature.Flat, 
                Notes = new[] { 
                    $"B{Signature.Flat.ToUnicode()}", 
                    "C", "D", 
                    $"E{Signature.Flat.ToUnicode()}", 
                    "F", "G", "A",
                    $"B{Signature.Flat.ToUnicode()}"},
            });
            Scales.Add(new Scale
            {
                Key = Key.A,
                Form = ScaleForm.Minor,
                Notes = new[] { "A", "B", "C", "D", "E", "F", "G", "A" },
            });
            comboBoxScales.TabStop= false;
            comboBoxScales.DropDownStyle= ComboBoxStyle.DropDownList;
            // Attach the list of scales
            FilteredScales = new BindingListView<Scale>(Scales);
            comboBoxScales.DataSource= FilteredScales;
            onRadioMajorChecked(this, EventArgs.Empty);
            // Initialize the value
            onScaleSelectionChanged(this, EventArgs.Empty);
            // Respond to combo box changes
            comboBoxScales.SelectedIndexChanged += onScaleSelectionChanged;
            // Respond to click randomize
            buttonRandomize.Click += onClickRandomize;
            // Respond to automated timer checkbox changes
            checkBoxTimer.CheckedChanged += onTimerCheckedChanged;
            // Apply filter
            radioButtonMajor.CheckedChanged += onRadioMajorChecked;
            radioButton2.CheckedChanged += onRadioMinorChecked;
        }

        private void onRadioMajorChecked(object? sender, EventArgs e)
        {
            FilteredScales.ApplyFilter(_ => _.Form.Equals(ScaleForm.Major));
            onScaleSelectionChanged(sender, e);
        }
        private void onRadioMinorChecked(object? sender, EventArgs e)
        {
            FilteredScales.ApplyFilter(_ => _.Form.Equals(ScaleForm.Minor));
            onScaleSelectionChanged(sender, e);
        }

        List<Scale> Scales = new List<Scale>();

        // https://stackoverflow.com/a/165333/5438626
        BindingListView<Scale> FilteredScales;

        private void onScaleSelectionChanged(object? sender, EventArgs e)
        {
            if(comboBoxScales.TryGetSelectedScale(out Scale? scale))
            {
                labelCurrentNote.Text = scale!.Notes[0];
            }
            // https://stackoverflow.com/a/24417483/5438626
            this.ActiveControl = null;
        }

        // Declare random generator ONCE
        private readonly Random _rando = new Random();
        private void onClickRandomize(object? sender, EventArgs e) =>
            execNextRandom(sender, e);
        private void execNextRandom(object? sender, EventArgs e)
        {
            if (comboBoxScales.TryGetSelectedScale(out Scale? scale))
            {
                string preview;
                do
                {
                    // Randomize, but do not repeat because it makes
                    // it seem like the button doesn't work!
                    var noteIndex = _rando.Next(0, scale!.Notes.Length);
                    preview = scale!.Notes[noteIndex];
                } while (preview.Equals(labelCurrentNote.Text));
                labelCurrentNote.Text = preview;
            }
            else
            {
                labelCurrentNote.Text = "*";
            }
        }

        private async void onTimerCheckedChanged(object? sender, EventArgs e)
        {
            while (checkBoxTimer.Checked)
            {
                execNextRandom(sender, e);
                await Task.Delay(TimeSpan.FromSeconds((double)numericUpDownSeconds.Value));
            }
        }
    }
    
    enum ScaleForm { Major, Minor }
    enum Key { A, B, C, D, E, F, G }
    enum Signature { Natural, [Description("\u266F")] Sharp, [Description("\u266D")] Flat }
    class Scale
    {
        public Key Key { get; set; }
        public ScaleForm Form { get; set; }
        public Signature Signature { get; set; }
        public string[] Notes { get; set; } = new string[0];
        // Determines what displays in the ComboBox
        public override string ToString()=> $"{Key}{Signature.ToUnicode()} {Form}";
    }
    static class Extensions
    {
        public static string ToUnicode(this Signature signature)
        {
            switch (signature)
            {
                default: return string.Empty;
                case Signature.Sharp: return "\u266F";
                case Signature.Flat: return "\u266D";
            }
        }
        public static bool TryGetSelectedScale(this ComboBox @this, out Scale? scale)
        {
            scale = (Scale)((ObjectView<Scale>)@this.SelectedItem);
            return scale != null;
        }
    }
}