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
            this.labelCurrentNote.AutoSize = true;
            this.labelCurrentNote.Font = new System.Drawing.Font("Segoe UI", 100F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelCurrentNote.Location = new System.Drawing.Point(120, 67);
            this.labelCurrentNote.Name = "labelCurrentNote";
            this.labelCurrentNote.Size = new System.Drawing.Size(213, 265);
            this.labelCurrentNote.TabIndex = 2;
            this.labelCurrentNote.Text = "E";
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.ClientSize = new System.Drawing.Size(492, 720);
            this.Controls.Add(this.buttonRandomize);
            this.Controls.Add(this.labelCurrentNote);
            this.Controls.Add(this.labelScale);
            this.Controls.Add(this.comboBoxScales);
            this.Name = "MainForm";
            this.Text = "Piano Memorization Tool";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBox comboBoxScales;
        private Label labelScale;
        private Label labelCurrentNote;
        private Button buttonRandomize;
    }
}