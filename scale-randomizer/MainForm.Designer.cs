namespace scale_randomizer
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBoxScales = new System.Windows.Forms.ComboBox();
            this.labelScale = new System.Windows.Forms.Label();
            this.labelCurrentNote = new System.Windows.Forms.Label();
            this.buttonRandomize = new System.Windows.Forms.Button();
            this.checkBoxTimer = new System.Windows.Forms.CheckBox();
            this.numericUpDownSeconds = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.radioButtonMajor = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSeconds)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxScales
            // 
            this.comboBoxScales.FormattingEnabled = true;
            this.comboBoxScales.Location = new System.Drawing.Point(32, 471);
            this.comboBoxScales.Name = "comboBoxScales";
            this.comboBoxScales.Size = new System.Drawing.Size(182, 33);
            this.comboBoxScales.TabIndex = 0;
            // 
            // labelScale
            // 
            this.labelScale.AutoSize = true;
            this.labelScale.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelScale.Location = new System.Drawing.Point(32, 433);
            this.labelScale.Name = "labelScale";
            this.labelScale.Size = new System.Drawing.Size(86, 25);
            this.labelScale.TabIndex = 1;
            this.labelScale.Text = "SCALE:";
            // 
            // labelCurrentNote
            // 
            this.labelCurrentNote.Font = new System.Drawing.Font("Segoe UI", 100F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelCurrentNote.Location = new System.Drawing.Point(32, 67);
            this.labelCurrentNote.Name = "labelCurrentNote";
            this.labelCurrentNote.Size = new System.Drawing.Size(405, 265);
            this.labelCurrentNote.TabIndex = 2;
            this.labelCurrentNote.Text = "E";
            this.labelCurrentNote.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonRandomize
            // 
            this.buttonRandomize.BackColor = System.Drawing.Color.LightGray;
            this.buttonRandomize.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonRandomize.Location = new System.Drawing.Point(32, 352);
            this.buttonRandomize.Name = "buttonRandomize";
            this.buttonRandomize.Size = new System.Drawing.Size(405, 43);
            this.buttonRandomize.TabIndex = 3;
            this.buttonRandomize.Text = "RANDOMIZE";
            this.buttonRandomize.UseVisualStyleBackColor = false;
            // 
            // checkBoxTimer
            // 
            this.checkBoxTimer.AutoSize = true;
            this.checkBoxTimer.Location = new System.Drawing.Point(263, 432);
            this.checkBoxTimer.Name = "checkBoxTimer";
            this.checkBoxTimer.Size = new System.Drawing.Size(177, 29);
            this.checkBoxTimer.TabIndex = 4;
            this.checkBoxTimer.Text = "Automated Timer";
            this.checkBoxTimer.UseVisualStyleBackColor = true;
            // 
            // numericUpDownSeconds
            // 
            this.numericUpDownSeconds.DecimalPlaces = 1;
            this.numericUpDownSeconds.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericUpDownSeconds.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numericUpDownSeconds.Location = new System.Drawing.Point(263, 636);
            this.numericUpDownSeconds.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numericUpDownSeconds.Name = "numericUpDownSeconds";
            this.numericUpDownSeconds.Size = new System.Drawing.Size(121, 39);
            this.numericUpDownSeconds.TabIndex = 5;
            this.numericUpDownSeconds.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDownSeconds.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(263, 599);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "Interval (secs):";
            // 
            // radioButton1
            // 
            this.radioButtonMajor.AutoSize = true;
            this.radioButtonMajor.Checked = true;
            this.radioButtonMajor.Location = new System.Drawing.Point(32, 642);
            this.radioButtonMajor.Name = "radioButton1";
            this.radioButtonMajor.Size = new System.Drawing.Size(83, 29);
            this.radioButtonMajor.TabIndex = 7;
            this.radioButtonMajor.TabStop = true;
            this.radioButtonMajor.Text = "Major";
            this.radioButtonMajor.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(131, 642);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(84, 29);
            this.radioButton2.TabIndex = 7;
            this.radioButton2.Text = "Minor";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.ClientSize = new System.Drawing.Size(492, 720);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButtonMajor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDownSeconds);
            this.Controls.Add(this.checkBoxTimer);
            this.Controls.Add(this.buttonRandomize);
            this.Controls.Add(this.labelCurrentNote);
            this.Controls.Add(this.labelScale);
            this.Controls.Add(this.comboBoxScales);
            this.Name = "MainForm";
            this.Text = "Piano Memorization Tool";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSeconds)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBox comboBoxScales;
        private Label labelScale;
        private Label labelCurrentNote;
        private Button buttonRandomize;
        private CheckBox checkBoxTimer;
        private NumericUpDown numericUpDownSeconds;
        private Label label1;
        private RadioButton radioButtonMajor;
        private RadioButton radioButton2;
    }
}