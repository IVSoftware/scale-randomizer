using System.ComponentModel;
using System.Globalization;

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
                Tonic = Key.C,
                Notes = new[] { "C", "D", "E", "F", "G", "A", "B", "C", },
            });
            Scales.Add(new Scale
            {
                Tonic = Key.D,
                Notes = new[] { "D", "E", "F#", "G", "A", "B", "C#", "D", },
            });
            Scales.Add(new Scale
            {
                Tonic = Key.E,
                Notes = new[] { "E", "F#", "G#", "A", "B", "C#", "D#", "E", },
            });
            Scales.Add(new Scale
            {
                Tonic = Key.F,
                Notes = new[] { "F", "G", "A", "Bb", "C", "D", "E", "F", },
            });
            Scales.Add(new Scale
            {
                Tonic = Key.G,
                Notes = new[] { "G", "A", "B", "C", "D", "E", "F#", "G", },
            });
            Scales.Add(new Scale
            {
                Tonic = Key.B, Signature = Signature.Flat, 
                Notes = new[] { 
                    $"B{Signature.Flat.ToUnicode()}", 
                    "C", "D", 
                    $"E{Signature.Flat.ToUnicode()}", 
                    "F", "G", "A",
                    $"B{Signature.Flat.ToUnicode()}"},
            });
            comboBoxScales.TabStop= false;
            comboBoxScales.DropDownStyle= ComboBoxStyle.DropDownList;
            // Attach the list of scales
            comboBoxScales.DataSource= Scales;
            // Initialize the value
            onScaleSelectionChanged(this, EventArgs.Empty);
            // Respond to combo box changes
            comboBoxScales.SelectedIndexChanged += onScaleSelectionChanged;
            // Respond to click randomize
            buttonRandomize.Click += onClickRandomize;
            // Respond to automated timer checkbox changes
            checkBoxTimer.CheckedChanged += onTimerCheckedChanged;
        }

        BindingList<Scale> Scales = new BindingList<Scale>();

        private void onScaleSelectionChanged(object? sender, EventArgs e)
        {
            labelCurrentNote.Text =
                ((Scale)comboBoxScales.SelectedItem).Notes[0];
            // https://stackoverflow.com/a/24417483/5438626
            this.ActiveControl = null;
        }

        // Declare random generator ONCE
        private readonly Random _rando = new Random();
        private void onClickRandomize(object? sender, EventArgs e) =>
            execNextRandom(sender, e);
        private void execNextRandom(object? sender, EventArgs e)
        {
            string preview;
            do
            {
                // Randomize, but do not repeat because it makes
                // it seem like the button doesn't work!
                preview =
                   ((Scale)comboBoxScales.SelectedItem)
                   .Notes[_rando.Next(0, 8)];
            } while (preview.Equals(labelCurrentNote.Text));
            labelCurrentNote.Text = preview;
        }

        private async void onTimerCheckedChanged(object? sender, EventArgs e)
        {
            if(checkBoxTimer.Checked) 
            {
                while(checkBoxTimer.Checked) 
                {
                    execNextRandom(sender, e);
                    await Task.Delay(TimeSpan.FromSeconds((double)numericUpDownSeconds.Value));
                }
            }
        }
    }
    
    enum ScaleForm { Major, Minor }
    enum Key { A, B, C, D, E, F, G }
    enum Signature { Natural, [Description("\u266F")] Sharp, [Description("\u266D")] Flat }
    class Scale
    {
        public Key Tonic { get; set; }
        public ScaleForm Form { get; set; }
        public Signature Signature { get; set; }
        public string[] Notes { get; set; } = new string[0];
        // Determines what displays in the ComboBox
        public override string ToString()=> $"{Tonic}{Signature.ToUnicode()} {Form}";
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
    }
}