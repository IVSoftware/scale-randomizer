Your question and code cover a few related areas:

- Dynamically change which array (of notes) is used for the label based on combo box selection.
- Use the `Random` class correctly to implement the Randomize function.
- Automate the Randomize button with a timer.

Ok, you did say **I'm open to an entire new solution if needed!** so this answer _will_ explore other ways to go about these three things and give you a couple new skills to try out. In particular, if you learn how to use Data Binding early on (as shown in this sample) it's likely to accelerate everything else you ever do in WinForms.

[![screenshot][1]][1]

***
**Binding the Scales to the ComboBox**

One approach is to define a `class` that represents a Scale. This associates the information more tightly than a dictionary lookup would. The `ToString` method will determine what's shown in the combo box.

    enum ScaleForm { Major, Minor }
    enum Key { A, B, C, D, E, F, G }
    enum Signature { Natural, [Description("\u266F")] Sharp, [Description("\u266D")] Flat }
    class Scale
    {
        public Key Key{ get; set; }
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

Next make a list of `Scale` objects that will be the dynamic source of the combo box:

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
            // Apply filter
            radioButtonMajor.CheckedChanged += onRadioMajorChecked;
            radioButton2.CheckedChanged += onRadioMinorChecked;
        }
        .
        .
        .
    }

Also in the same method, the event handlers are attached. For example, when a new scale is chosen in the combo box, the first thing that happens is that the label is set to the root.

    private void onScaleSelectionChanged(object? sender, EventArgs e)
    {
        if(comboBoxScales.TryGetSelectedScale(out Scale? scale))
        {
            labelCurrentNote.Text = scale!.Notes[0];
        }
    }

Radio button changes cause new filtering to be applied

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

***
**Using the `Random` class**

You only need one instance of `Random`. For testing, you can produce the _same_ pseudorandom sequence of numbers every time by seeding it with an int, e.g. `new Random(1)`. But as shown here, the seed is derived from the system clock for a different sequence every time you run it.

    private readonly Random _rando = new Random();
    private void onClickRandomize(object? sender, EventArgs e) =>
        execNextRandom(sender, e);

One implementation would be to get a number between 0 and 7 inclusive, and use it to dereference an array value from the current selection in the combo box. This also makes a point of getting a _new_ note on every click so the user feels confident when they click.

    private void execNextRandom(object? sender, EventArgs e)
    {
        string preview;
        do
        {
            // Randomize, but do not repeat because it makes
            // it seem like the button doesn't work!
            preview =
                ((Scale)comboBoxScales.SelectedItem)
                .Notes[_rando.Next(0, 8)];  // Will never return 8!
        } while (preview.Equals(labelCurrentNote.Text));
        labelCurrentNote.Text = preview;
    }

***
**Automated timer**

One of the easier ways to get a repeating function is to make an async handler for the timer checkbox. There's no need to start and stop a Timer or handle events this way, but it still offers the advantages of keeping your UI responsive by 'not' blocking the thread except for when the new random note is acquired. 

    private async void onTimerCheckedChanged(object? sender, EventArgs e)
    {
        while(checkBoxTimer.Checked) 
        {
            execNextRandom(sender, e);
            await Task.Delay(TimeSpan.FromSeconds((double)numericUpDownSeconds.Value));
        }
    }


  [1]: https://i.stack.imgur.com/WUPCc.png
