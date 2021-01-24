    partial class RequestInfo
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
		private System.Windows.Forms.Label filePath;
		private System.Windows.Forms.Button fileBrowseButton;
		private System.Windows.Forms.Button folderBrowseButton;
		private System.Windows.Forms.Label folderPath;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.filePath = new System.Windows.Forms.Label();
			this.fileBrowseButton = new System.Windows.Forms.Button();
			this.folderBrowseButton = new System.Windows.Forms.Button();
			this.folderPath = new System.Windows.Forms.Label();
			this.cancelButton = new System.Windows.Forms.Button();
			this.okButton = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// openFileDialog
			// 
			this.openFileDialog.FileName = "openFileDialog";
			this.openFileDialog.Filter = "CVD Files|*.cvd";
			// 
			// filePath
			// 
			this.filePath.AutoSize = true;
			this.filePath.Location = new System.Drawing.Point(93, 17);
			this.filePath.Name = "filePath";
			this.filePath.Size = new System.Drawing.Size(85, 13);
			this.filePath.TabIndex = 0;
			this.filePath.Text = "No File Selected";
			this.filePath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// fileBrowseButton
			// 
			this.fileBrowseButton.Location = new System.Drawing.Point(12, 12);
			this.fileBrowseButton.Name = "fileBrowseButton";
			this.fileBrowseButton.Size = new System.Drawing.Size(75, 23);
			this.fileBrowseButton.TabIndex = 1;
			this.fileBrowseButton.Text = "Browse";
			this.fileBrowseButton.UseVisualStyleBackColor = true;
			this.fileBrowseButton.Click += new System.EventHandler(this.fileBrowseButton_Click);
			// 
			// folderBrowseButton
			// 
			this.folderBrowseButton.Location = new System.Drawing.Point(12, 51);
			this.folderBrowseButton.Name = "folderBrowseButton";
			this.folderBrowseButton.Size = new System.Drawing.Size(75, 23);
			this.folderBrowseButton.TabIndex = 2;
			this.folderBrowseButton.Text = "Browse";
			this.folderBrowseButton.UseVisualStyleBackColor = true;
			this.folderBrowseButton.Click += new System.EventHandler(this.folderBrowseButton_Click);
			// 
			// folderPath
			// 
			this.folderPath.AutoSize = true;
			this.folderPath.Location = new System.Drawing.Point(93, 56);
			this.folderPath.Name = "folderPath";
			this.folderPath.Size = new System.Drawing.Size(98, 13);
			this.folderPath.TabIndex = 3;
			this.folderPath.Text = "No Folder Selected";
			this.folderPath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cancelButton
			// 
			this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelButton.Location = new System.Drawing.Point(546, 10);
			this.cancelButton.Margin = new System.Windows.Forms.Padding(0);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(75, 23);
			this.cancelButton.TabIndex = 4;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
			// 
			// okButton
			// 
			this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.okButton.Location = new System.Drawing.Point(465, 10);
			this.okButton.Margin = new System.Windows.Forms.Padding(0);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(75, 23);
			this.okButton.TabIndex = 5;
			this.okButton.Text = "OK";
			this.okButton.UseVisualStyleBackColor = true;
			this.okButton.Click += new System.EventHandler(this.okButton_Click);
			// 
			// panel1
			// 
			this.panel1.AutoSize = true;
			this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.panel1.Controls.Add(this.okButton);
			this.panel1.Controls.Add(this.cancelButton);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 298);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
			this.panel1.Size = new System.Drawing.Size(633, 43);
			this.panel1.TabIndex = 6;
			// 
			// panel2
			// 
			this.panel2.AutoSize = true;
			this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.panel2.Controls.Add(this.fileBrowseButton);
			this.panel2.Controls.Add(this.folderBrowseButton);
			this.panel2.Controls.Add(this.folderPath);
			this.panel2.Controls.Add(this.filePath);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(633, 298);
			this.panel2.TabIndex = 7;
			// 
			// RequestInfo
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ClientSize = new System.Drawing.Size(633, 341);
			this.ControlBox = false;
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(300, 200);
			this.Name = "RequestInfo";
			this.Text = "RequestInfo";
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
	}
