using System.ComponentModel;

namespace scale_randomizer
{
    public partial class MainForm : Form
    {
        public MainForm() => InitializeComponent();

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Scales.Add(new scale_randomizer.Scale
            {
                Name = "C Major",
                Notes = new[]{ "C", "D", "E", "F", "G", "A", "B", "C", },
            });
            Scales.Add(new scale_randomizer.Scale
            {
                Name = "D Major",
                Notes = new[] { "D", "E", "F#", "G", "A", "B", "C#", "D", },
            });
            Scales.Add(new scale_randomizer.Scale
            {
                Name = "E Major",
                Notes = new[] { "E", "F#", "G#", "A", "B", "C#", "D#", "E", },
            });
            Scales.Add(new scale_randomizer.Scale
            {
                Name = "F Major",
                Notes = new[] { "F", "G", "A", "Bb", "C", "D", "E", "F", },
            });
            Scales.Add(new scale_randomizer.Scale
            {
                Name = "G Major",
                Notes = new[] { "G", "A", "B", "C", "D", "E", "F#", "G", },
            });
            comboBoxScales.TabStop = false;
            comboBoxScales.DropDownStyle= ComboBoxStyle.DropDownList;
            comboBoxScales.DataSource= Scales;
            onScaleSelectionChanged(this, EventArgs.Empty); // Init value
            comboBoxScales.SelectedIndexChanged += onScaleSelectionChanged;
            buttonRandomize.Click += onClickRandomize;
        }

        private void onClickRandomize(object? sender, EventArgs e)
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

        private void onScaleSelectionChanged(object? sender, EventArgs e)
        {
            labelCurrentNote.Text = 
                ((Scale)comboBoxScales.SelectedItem).Notes[0];
            // https://stackoverflow.com/a/24417483/5438626
            this.ActiveControl = null;
        }

        BindingList<Scale> Scales = new BindingList<Scale>();
        // Declare random generator ONCE
        private readonly Random _rando = new Random();
    }

    class Scale
    {
        public string Name { get; set; } = string.Empty;
        public string[] Notes { get; set; } = new string[0];
        public override string ToString() => Name;
    }
}