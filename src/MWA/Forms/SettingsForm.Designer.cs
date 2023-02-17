namespace MWA.Forms
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            pictureBox1 = new PictureBox();
            button1 = new Button();
            button2 = new Button();
            groupBox1 = new GroupBox();
            label1 = new Label();
            stopOnLockCheckBox = new CheckBox();
            groupBox2 = new GroupBox();
            label3 = new Label();
            stopMouseWigglingCheckBox = new CheckBox();
            maxElapsedLabel = new Label();
            label2 = new Label();
            maxElapsedTrackBar = new TrackBar();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)maxElapsedTrackBar).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Resources.codegator_167x79;
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(368, 88);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // button1
            // 
            button1.DialogResult = DialogResult.Cancel;
            button1.Location = new Point(12, 366);
            button1.Name = "button1";
            button1.Size = new Size(94, 34);
            button1.TabIndex = 5;
            button1.Text = "Cancel";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.DialogResult = DialogResult.OK;
            button2.Location = new Point(286, 366);
            button2.Name = "button2";
            button2.Size = new Size(94, 34);
            button2.TabIndex = 6;
            button2.Text = "OK";
            button2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(stopOnLockCheckBox);
            groupBox1.Location = new Point(12, 106);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(368, 73);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "Desktop";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.Info;
            label1.ForeColor = SystemColors.InfoText;
            label1.Location = new Point(11, 44);
            label1.Name = "label1";
            label1.Size = new Size(266, 15);
            label1.TabIndex = 1;
            label1.Text = "Stop wiggling the mouse when the desktop locks";
            // 
            // stopOnLockCheckBox
            // 
            stopOnLockCheckBox.AutoSize = true;
            stopOnLockCheckBox.Location = new Point(11, 22);
            stopOnLockCheckBox.Name = "stopOnLockCheckBox";
            stopOnLockCheckBox.Size = new Size(97, 19);
            stopOnLockCheckBox.TabIndex = 0;
            stopOnLockCheckBox.Text = "Stop On Lock";
            stopOnLockCheckBox.UseVisualStyleBackColor = true;
            stopOnLockCheckBox.CheckedChanged += stopOnLockCheckBox_CheckedChanged;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(stopMouseWigglingCheckBox);
            groupBox2.Controls.Add(maxElapsedLabel);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(maxElapsedTrackBar);
            groupBox2.Location = new Point(12, 185);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(368, 172);
            groupBox2.TabIndex = 8;
            groupBox2.TabStop = false;
            groupBox2.Text = "Mouse";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = SystemColors.Info;
            label3.ForeColor = SystemColors.InfoText;
            label3.Location = new Point(11, 141);
            label3.Name = "label3";
            label3.Size = new Size(134, 15);
            label3.TabIndex = 4;
            label3.Text = "Stop all mouse wiggling";
            // 
            // stopMouseWigglingCheckBox
            // 
            stopMouseWigglingCheckBox.AutoSize = true;
            stopMouseWigglingCheckBox.Location = new Point(11, 118);
            stopMouseWigglingCheckBox.Name = "stopMouseWigglingCheckBox";
            stopMouseWigglingCheckBox.Size = new Size(154, 19);
            stopMouseWigglingCheckBox.TabIndex = 3;
            stopMouseWigglingCheckBox.Text = "Disable Mouse Wiggling";
            stopMouseWigglingCheckBox.UseVisualStyleBackColor = true;
            stopMouseWigglingCheckBox.CheckedChanged += stopMouseWigglingCheckBox_CheckedChanged;
            // 
            // maxElapsedLabel
            // 
            maxElapsedLabel.AutoSize = true;
            maxElapsedLabel.BackColor = SystemColors.Info;
            maxElapsedLabel.ForeColor = SystemColors.InfoText;
            maxElapsedLabel.Location = new Point(11, 83);
            maxElapsedLabel.Name = "maxElapsedLabel";
            maxElapsedLabel.Size = new Size(246, 15);
            maxElapsedLabel.TabIndex = 2;
            maxElapsedLabel.Text = "Max minutes between mouse wiggles (1 to 5)";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(11, 19);
            label2.Name = "label2";
            label2.Size = new Size(105, 15);
            label2.TabIndex = 1;
            label2.Text = "Maximum Elapsed";
            // 
            // maxElapsedTrackBar
            // 
            maxElapsedTrackBar.Location = new Point(11, 49);
            maxElapsedTrackBar.Maximum = 5;
            maxElapsedTrackBar.Minimum = 1;
            maxElapsedTrackBar.Name = "maxElapsedTrackBar";
            maxElapsedTrackBar.Size = new Size(351, 45);
            maxElapsedTrackBar.TabIndex = 0;
            maxElapsedTrackBar.Value = 1;
            maxElapsedTrackBar.ValueChanged += maxElapsedTrackBar_ValueChanged;
            // 
            // SettingsForm
            // 
            AcceptButton = button2;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = button1;
            ClientSize = new Size(397, 412);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SettingsForm";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MWA Settings";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)maxElapsedTrackBar).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private Button button1;
        private Button button2;
        private GroupBox groupBox1;
        private CheckBox stopOnLockCheckBox;
        private Label label1;
        private GroupBox groupBox2;
        private Label maxElapsedLabel;
        private Label label2;
        private TrackBar maxElapsedTrackBar;
        private Label label3;
        private CheckBox stopMouseWigglingCheckBox;
    }
}