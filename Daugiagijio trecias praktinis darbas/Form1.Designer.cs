
namespace Daugiagijio_trecias_praktinis_darbas
{
    partial class Form1
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
            this.openFolderButton = new System.Windows.Forms.Button();
            this.arffCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.checkAllButton = new System.Windows.Forms.Button();
            this.combineButton = new System.Windows.Forms.Button();
            this.uncheckAllButton = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.pauseButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.continueButton = new System.Windows.Forms.Button();
            this.checkLabel = new System.Windows.Forms.Label();
            this.progressBarForCheck = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // openFolderButton
            // 
            this.openFolderButton.Location = new System.Drawing.Point(49, 31);
            this.openFolderButton.Name = "openFolderButton";
            this.openFolderButton.Size = new System.Drawing.Size(75, 23);
            this.openFolderButton.TabIndex = 0;
            this.openFolderButton.Text = "Open Folder";
            this.openFolderButton.UseVisualStyleBackColor = true;
            this.openFolderButton.Click += new System.EventHandler(this.openFolderButton_Click);
            // 
            // arffCheckedListBox
            // 
            this.arffCheckedListBox.FormattingEnabled = true;
            this.arffCheckedListBox.Location = new System.Drawing.Point(49, 83);
            this.arffCheckedListBox.Name = "arffCheckedListBox";
            this.arffCheckedListBox.Size = new System.Drawing.Size(548, 244);
            this.arffCheckedListBox.TabIndex = 1;
            // 
            // checkAllButton
            // 
            this.checkAllButton.Location = new System.Drawing.Point(227, 333);
            this.checkAllButton.Name = "checkAllButton";
            this.checkAllButton.Size = new System.Drawing.Size(75, 23);
            this.checkAllButton.TabIndex = 2;
            this.checkAllButton.Text = "Check All";
            this.checkAllButton.UseVisualStyleBackColor = true;
            this.checkAllButton.Visible = false;
            this.checkAllButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // combineButton
            // 
            this.combineButton.Enabled = false;
            this.combineButton.Location = new System.Drawing.Point(270, 373);
            this.combineButton.Name = "combineButton";
            this.combineButton.Size = new System.Drawing.Size(75, 23);
            this.combineButton.TabIndex = 3;
            this.combineButton.Text = "Combine";
            this.combineButton.UseVisualStyleBackColor = true;
            this.combineButton.Click += new System.EventHandler(this.combineButton_Click);
            // 
            // uncheckAllButton
            // 
            this.uncheckAllButton.Location = new System.Drawing.Point(308, 333);
            this.uncheckAllButton.Name = "uncheckAllButton";
            this.uncheckAllButton.Size = new System.Drawing.Size(75, 23);
            this.uncheckAllButton.TabIndex = 6;
            this.uncheckAllButton.Text = "Uncheck All";
            this.uncheckAllButton.UseVisualStyleBackColor = true;
            this.uncheckAllButton.Visible = false;
            this.uncheckAllButton.Click += new System.EventHandler(this.uncheckAllButton_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(21, 415);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(615, 23);
            this.progressBar.TabIndex = 7;
            // 
            // pauseButton
            // 
            this.pauseButton.Enabled = false;
            this.pauseButton.Location = new System.Drawing.Point(94, 457);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(75, 23);
            this.pauseButton.TabIndex = 8;
            this.pauseButton.Text = "Pause";
            this.pauseButton.UseVisualStyleBackColor = true;
            this.pauseButton.Click += new System.EventHandler(this.pauseButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Enabled = false;
            this.cancelButton.Location = new System.Drawing.Point(270, 457);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 9;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click_1);
            // 
            // continueButton
            // 
            this.continueButton.Enabled = false;
            this.continueButton.Location = new System.Drawing.Point(462, 457);
            this.continueButton.Name = "continueButton";
            this.continueButton.Size = new System.Drawing.Size(75, 23);
            this.continueButton.TabIndex = 10;
            this.continueButton.Text = "Continue";
            this.continueButton.UseVisualStyleBackColor = true;
            this.continueButton.Click += new System.EventHandler(this.continueButton_Click);
            // 
            // checkLabel
            // 
            this.checkLabel.AutoSize = true;
            this.checkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkLabel.Location = new System.Drawing.Point(192, 184);
            this.checkLabel.Name = "checkLabel";
            this.checkLabel.Size = new System.Drawing.Size(254, 24);
            this.checkLabel.TabIndex = 12;
            this.checkLabel.Text = "Checking for corrupted files...";
            this.checkLabel.Visible = false;
            // 
            // progressBarForCheck
            // 
            this.progressBarForCheck.Location = new System.Drawing.Point(179, 211);
            this.progressBarForCheck.Name = "progressBarForCheck";
            this.progressBarForCheck.Size = new System.Drawing.Size(277, 14);
            this.progressBarForCheck.TabIndex = 13;
            this.progressBarForCheck.Visible = false;
            this.progressBarForCheck.Click += new System.EventHandler(this.progressBar1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 492);
            this.Controls.Add(this.progressBarForCheck);
            this.Controls.Add(this.checkLabel);
            this.Controls.Add(this.continueButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.pauseButton);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.uncheckAllButton);
            this.Controls.Add(this.combineButton);
            this.Controls.Add(this.checkAllButton);
            this.Controls.Add(this.arffCheckedListBox);
            this.Controls.Add(this.openFolderButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button openFolderButton;
        private System.Windows.Forms.CheckedListBox arffCheckedListBox;
        private System.Windows.Forms.Button checkAllButton;
        private System.Windows.Forms.Button combineButton;
        private System.Windows.Forms.Button uncheckAllButton;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button pauseButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button continueButton;
        private System.Windows.Forms.Label checkLabel;
        private System.Windows.Forms.ProgressBar progressBarForCheck;
    }
}

