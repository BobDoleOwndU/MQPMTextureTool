namespace MQPMTextureTool
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.openFileLabel = new System.Windows.Forms.Label();
            this.openFolderTextBox = new System.Windows.Forms.TextBox();
            this.openFileButton = new System.Windows.Forms.Button();
            this.processButton = new System.Windows.Forms.Button();
            this.authorLabel = new System.Windows.Forms.Label();
            this.textureListBox = new System.Windows.Forms.ListBox();
            this.previewPictureBox = new System.Windows.Forms.PictureBox();
            this.textureLabel = new System.Windows.Forms.Label();
            this.previewLabel = new System.Windows.Forms.Label();
            this.outfitComboBox = new System.Windows.Forms.ComboBox();
            this.outfitLabel = new System.Windows.Forms.Label();
            this.warpaintButton = new System.Windows.Forms.Button();
            this.characterLabel = new System.Windows.Forms.Label();
            this.characterComboBox = new System.Windows.Forms.ComboBox();
            this.processShirtButton = new System.Windows.Forms.Button();
            this.fatiguesButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.previewPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileLabel
            // 
            this.openFileLabel.AutoSize = true;
            this.openFileLabel.Location = new System.Drawing.Point(8, 12);
            this.openFileLabel.Name = "openFileLabel";
            this.openFileLabel.Size = new System.Drawing.Size(189, 13);
            this.openFileLabel.TabIndex = 0;
            this.openFileLabel.Text = "Select the MQPM Tool\'s Output Folder";
            // 
            // openFolderTextBox
            // 
            this.openFolderTextBox.Location = new System.Drawing.Point(12, 28);
            this.openFolderTextBox.Name = "openFolderTextBox";
            this.openFolderTextBox.Size = new System.Drawing.Size(121, 20);
            this.openFolderTextBox.TabIndex = 1;
            // 
            // openFileButton
            // 
            this.openFileButton.Location = new System.Drawing.Point(139, 26);
            this.openFileButton.Name = "openFileButton";
            this.openFileButton.Size = new System.Drawing.Size(24, 23);
            this.openFileButton.TabIndex = 2;
            this.openFileButton.Text = "...";
            this.openFileButton.UseVisualStyleBackColor = true;
            this.openFileButton.Click += new System.EventHandler(this.openFileButton_Click);
            // 
            // processButton
            // 
            this.processButton.Location = new System.Drawing.Point(11, 377);
            this.processButton.Name = "processButton";
            this.processButton.Size = new System.Drawing.Size(81, 23);
            this.processButton.TabIndex = 3;
            this.processButton.Text = "Apply to Outfit";
            this.processButton.UseVisualStyleBackColor = true;
            this.processButton.Click += new System.EventHandler(this.processButton_Click);
            // 
            // authorLabel
            // 
            this.authorLabel.AutoSize = true;
            this.authorLabel.Location = new System.Drawing.Point(258, 420);
            this.authorLabel.Name = "authorLabel";
            this.authorLabel.Size = new System.Drawing.Size(138, 13);
            this.authorLabel.TabIndex = 8;
            this.authorLabel.Text = "Created by BobDoleOwndU";
            // 
            // textureListBox
            // 
            this.textureListBox.FormattingEnabled = true;
            this.textureListBox.Location = new System.Drawing.Point(11, 107);
            this.textureListBox.Name = "textureListBox";
            this.textureListBox.Size = new System.Drawing.Size(120, 264);
            this.textureListBox.TabIndex = 10;
            this.textureListBox.SelectedIndexChanged += new System.EventHandler(this.textureListBox_SelectedIndexChanged);
            // 
            // previewPictureBox
            // 
            this.previewPictureBox.Location = new System.Drawing.Point(139, 107);
            this.previewPictureBox.Name = "previewPictureBox";
            this.previewPictureBox.Size = new System.Drawing.Size(256, 256);
            this.previewPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.previewPictureBox.TabIndex = 11;
            this.previewPictureBox.TabStop = false;
            // 
            // textureLabel
            // 
            this.textureLabel.AutoSize = true;
            this.textureLabel.Location = new System.Drawing.Point(8, 91);
            this.textureLabel.Name = "textureLabel";
            this.textureLabel.Size = new System.Drawing.Size(85, 13);
            this.textureLabel.TabIndex = 12;
            this.textureLabel.Text = "Select a Texture";
            // 
            // previewLabel
            // 
            this.previewLabel.AutoSize = true;
            this.previewLabel.Location = new System.Drawing.Point(136, 91);
            this.previewLabel.Name = "previewLabel";
            this.previewLabel.Size = new System.Drawing.Size(45, 13);
            this.previewLabel.TabIndex = 13;
            this.previewLabel.Text = "Preview";
            // 
            // outfitComboBox
            // 
            this.outfitComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.outfitComboBox.FormattingEnabled = true;
            this.outfitComboBox.Location = new System.Drawing.Point(139, 67);
            this.outfitComboBox.Name = "outfitComboBox";
            this.outfitComboBox.Size = new System.Drawing.Size(121, 21);
            this.outfitComboBox.TabIndex = 14;
            this.outfitComboBox.SelectedIndexChanged += new System.EventHandler(this.outfitComboBox_SelectedIndexChanged);
            // 
            // outfitLabel
            // 
            this.outfitLabel.AutoSize = true;
            this.outfitLabel.Location = new System.Drawing.Point(136, 52);
            this.outfitLabel.Name = "outfitLabel";
            this.outfitLabel.Size = new System.Drawing.Size(64, 13);
            this.outfitLabel.TabIndex = 15;
            this.outfitLabel.Text = "Player Outfit";
            // 
            // warpaintButton
            // 
            this.warpaintButton.Location = new System.Drawing.Point(186, 377);
            this.warpaintButton.Name = "warpaintButton";
            this.warpaintButton.Size = new System.Drawing.Size(82, 23);
            this.warpaintButton.TabIndex = 17;
            this.warpaintButton.Text = "Warpaint";
            this.warpaintButton.UseVisualStyleBackColor = true;
            this.warpaintButton.Click += new System.EventHandler(this.warpaintButton_Click);
            // 
            // characterLabel
            // 
            this.characterLabel.AutoSize = true;
            this.characterLabel.Location = new System.Drawing.Point(8, 51);
            this.characterLabel.Name = "characterLabel";
            this.characterLabel.Size = new System.Drawing.Size(85, 13);
            this.characterLabel.TabIndex = 18;
            this.characterLabel.Text = "Player Character";
            // 
            // characterComboBox
            // 
            this.characterComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.characterComboBox.FormattingEnabled = true;
            this.characterComboBox.Location = new System.Drawing.Point(12, 67);
            this.characterComboBox.Name = "characterComboBox";
            this.characterComboBox.Size = new System.Drawing.Size(121, 21);
            this.characterComboBox.TabIndex = 19;
            this.characterComboBox.SelectedIndexChanged += new System.EventHandler(this.characterComboBox_SelectedIndexChanged);
            // 
            // processShirtButton
            // 
            this.processShirtButton.Location = new System.Drawing.Point(98, 377);
            this.processShirtButton.Name = "processShirtButton";
            this.processShirtButton.Size = new System.Drawing.Size(82, 23);
            this.processShirtButton.TabIndex = 20;
            this.processShirtButton.Text = "Apply to Shirt";
            this.processShirtButton.UseVisualStyleBackColor = true;
            this.processShirtButton.Click += new System.EventHandler(this.processShirtButton_Click);
            // 
            // fatiguesButton
            // 
            this.fatiguesButton.Location = new System.Drawing.Point(274, 377);
            this.fatiguesButton.Name = "fatiguesButton";
            this.fatiguesButton.Size = new System.Drawing.Size(87, 23);
            this.fatiguesButton.TabIndex = 21;
            this.fatiguesButton.Text = "Fatigues Camo";
            this.fatiguesButton.UseVisualStyleBackColor = true;
            this.fatiguesButton.Click += new System.EventHandler(this.fatiguesButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 442);
            this.Controls.Add(this.fatiguesButton);
            this.Controls.Add(this.processShirtButton);
            this.Controls.Add(this.characterComboBox);
            this.Controls.Add(this.characterLabel);
            this.Controls.Add(this.warpaintButton);
            this.Controls.Add(this.outfitLabel);
            this.Controls.Add(this.outfitComboBox);
            this.Controls.Add(this.previewLabel);
            this.Controls.Add(this.textureLabel);
            this.Controls.Add(this.previewPictureBox);
            this.Controls.Add(this.textureListBox);
            this.Controls.Add(this.authorLabel);
            this.Controls.Add(this.processButton);
            this.Controls.Add(this.openFileButton);
            this.Controls.Add(this.openFolderTextBox);
            this.Controls.Add(this.openFileLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Multi Quiet Player Mod Texture Tool";
            ((System.ComponentModel.ISupportInitialize)(this.previewPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label openFileLabel;
        private System.Windows.Forms.TextBox openFolderTextBox;
        private System.Windows.Forms.Button openFileButton;
        private System.Windows.Forms.Button processButton;
        private System.Windows.Forms.Label authorLabel;
        private System.Windows.Forms.ListBox textureListBox;
        private System.Windows.Forms.PictureBox previewPictureBox;
        private System.Windows.Forms.Label textureLabel;
        private System.Windows.Forms.Label previewLabel;
        private System.Windows.Forms.ComboBox outfitComboBox;
        private System.Windows.Forms.Label outfitLabel;
        private System.Windows.Forms.Button warpaintButton;
        private System.Windows.Forms.Label characterLabel;
        private System.Windows.Forms.ComboBox characterComboBox;
        private System.Windows.Forms.Button processShirtButton;
        private System.Windows.Forms.Button fatiguesButton;
    }
}

