﻿namespace SwissAcademic.Addons.MacroManager
{
    partial class DirectoryDialog
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
            this.components = new System.ComponentModel.Container();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnFolderBrowserDialog = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.btnEnvironmentVariables = new System.Windows.Forms.Button();
            this.ccEnvironment = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.lblEnvironmentFullPath = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(212, 62);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(293, 62);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // btnFolderBrowserDialog
            // 
            this.btnFolderBrowserDialog.Location = new System.Drawing.Point(333, 25);
            this.btnFolderBrowserDialog.Name = "btnFolderBrowserDialog";
            this.btnFolderBrowserDialog.Size = new System.Drawing.Size(35, 20);
            this.btnFolderBrowserDialog.TabIndex = 3;
            this.btnFolderBrowserDialog.Text = "...";
            this.btnFolderBrowserDialog.UseVisualStyleBackColor = true;
            this.btnFolderBrowserDialog.Click += new System.EventHandler(this.BtnFolderBrowserDialog_Click);
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(15, 25);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(271, 20);
            this.txtPath.TabIndex = 4;
            this.txtPath.TextChanged += new System.EventHandler(this.TxtPath_TextChanged);
            // 
            // btnEnvironmentVariables
            // 
            this.btnEnvironmentVariables.Location = new System.Drawing.Point(292, 24);
            this.btnEnvironmentVariables.Name = "btnEnvironmentVariables";
            this.btnEnvironmentVariables.Size = new System.Drawing.Size(35, 21);
            this.btnEnvironmentVariables.TabIndex = 5;
            this.btnEnvironmentVariables.Text = "%";
            this.btnEnvironmentVariables.UseVisualStyleBackColor = true;
            this.btnEnvironmentVariables.Click += new System.EventHandler(this.BtnEnvironmentVariables_Click);
            // 
            // ccEnvironment
            // 
            this.ccEnvironment.Name = "ccEnvironment";
            this.ccEnvironment.Size = new System.Drawing.Size(61, 4);
            // 
            // lblEnvironmentFullPath
            // 
            this.lblEnvironmentFullPath.AutoSize = true;
            this.lblEnvironmentFullPath.Location = new System.Drawing.Point(12, 48);
            this.lblEnvironmentFullPath.Name = "lblEnvironmentFullPath";
            this.lblEnvironmentFullPath.Size = new System.Drawing.Size(0, 13);
            this.lblEnvironmentFullPath.TabIndex = 6;
            // 
            // DirectoryDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 97);
            this.Controls.Add(this.lblEnvironmentFullPath);
            this.Controls.Add(this.btnEnvironmentVariables);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.btnFolderBrowserDialog);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DirectoryDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DirectoryDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnFolderBrowserDialog;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button btnEnvironmentVariables;
        private System.Windows.Forms.ContextMenuStrip ccEnvironment;
        private System.Windows.Forms.Label lblEnvironmentFullPath;
    }
}