namespace MQPMTextureTool
{
    partial class FatiguesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FatiguesForm));
            this.camoLabel = new System.Windows.Forms.Label();
            this.camoComboBox = new System.Windows.Forms.ComboBox();
            this.applyButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // camoLabel
            // 
            this.camoLabel.AutoSize = true;
            this.camoLabel.Location = new System.Drawing.Point(9, 9);
            this.camoLabel.Name = "camoLabel";
            this.camoLabel.Size = new System.Drawing.Size(76, 13);
            this.camoLabel.TabIndex = 0;
            this.camoLabel.Text = "Select a Camo";
            // 
            // camoComboBox
            // 
            this.camoComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.camoComboBox.FormattingEnabled = true;
            this.camoComboBox.Location = new System.Drawing.Point(12, 25);
            this.camoComboBox.Name = "camoComboBox";
            this.camoComboBox.Size = new System.Drawing.Size(192, 21);
            this.camoComboBox.TabIndex = 1;
            this.camoComboBox.SelectedIndexChanged += new System.EventHandler(this.camoComboBox_SelectedIndexChanged);
            // 
            // applyButton
            // 
            this.applyButton.Location = new System.Drawing.Point(13, 53);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(75, 23);
            this.applyButton.TabIndex = 2;
            this.applyButton.Text = "Apply";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // FatiguesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(216, 90);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.camoComboBox);
            this.Controls.Add(this.camoLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FatiguesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fatigues";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label camoLabel;
        private System.Windows.Forms.ComboBox camoComboBox;
        private System.Windows.Forms.Button applyButton;
    }
}