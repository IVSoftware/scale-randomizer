Your question and code covers a few related areas:

- Dynamically change which array (of notes) is used for the label based on combo box selection.
- Use the `Random` class correctly to implement the Randomize function.
- Automate the Randomize button with a timer.

Ok, you did say **I'm open to an entire new solution if needed!** so this answer _will_ explore other ways to go about these three things and give you a couple new skills to try out. In particular, if you learn how to use Data Binding early on (as shown in this sample) it's likely to accelerate everything else you ever do in WinForms.

[![screenshot][1]][1]

***
**Binding the Scales to the ComboBox**

One approach is to define a `class` that represents a Scale. This associates the information more tightly than a dictionary lookup would. The `ToString` method will determine what's shown in the combo box.

    class Scale
    {
        public string Name { get; set; } = string.Empty;
        public string[] Notes { get; set; } = new string[0];

        // Determines what will show in the ComboBox
        public override string ToString() => Name;
    }

What we do next is make a list of `Scale` objects that will be the dynamic source of the combo box:

    BindingList<Scale> Scales = new BindingList<Scale>();

Initialize the individual scales _and_ the list of scales in the method that loads the main form.

    public partial class MainForm : Form
    {
        public MainForm() => InitializeComponent();

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Scales.Add(new Scale
            {
                Name = "C Major",
                Notes = new[]{ "C", "D", "E", "F", "G", "A", "B", "C", },
            });
            Scales.Add(new Scale
            {
                Name = "D Major",
                Notes = new[] { "D", "E", "F#", "G", "A", "B", "C#", "D", },
            });
            Scales.Add(new Scale
            {
                Name = "E Major",
                Notes = new[] { "E", "F#", "G#", "A", "B", "C#", "D#", "E", },
            });
            Scales.Add(new Scale
            {
                Name = "F Major",
                Notes = new[] { "F", "G", "A", "Bb", "C", "D", "E", "F", },
            });
            Scales.Add(new Scale
            {
                Name = "G Major",
                Notes = new[] { "G", "A", "B", "C", "D", "E", "F#", "G", },
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
        .
        .
        .
    }

Also in the same method, the event handlers are also attached. For example, when a new scale is chosen in the combo box, the first thing that happens is that the label is set to the root.

    private void onScaleSelectionChanged(object? sender, EventArgs e)
    {
        labelCurrentNote.Text =
            ((Scale)comboBoxScales.SelectedItem).Notes[0];
    }

***
**Using the `Random` class**

You only need one instance of `Random`. For testing, you can produce the _same_ pseudorandom sequence of numbers every time by seeding it with an int, e.g. `new Random(1)`. But as shown here, the seed is derived from the system clock.

    private readonly Random _rando = new Random();
    private void onClickRandomize(object? sender, EventArgs e) =>
        execNextRandom(sender, e);

One implementation would be to get a number between 0 and 7 inclusive, and use it to dereference an array value from the current selection in the combo box. This also makes a point of getting a _new_ not every click so the user feels confident when they click.

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

***
**Automated timer**

One of the easier ways to get a repeating function is to make an async handler for the timer checkbox. There's no need to start and stop a Timer or handle events this way, but it still offers the advantages of keeping your UI responsive by 'not' blocking the thread except for when the new random note is acquired. 

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


  [1]: https://i.stack.imgur.com/JIjDG.png