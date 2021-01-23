    		{
			this.ToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.ToolStripButton.Image = ((System.Windows.Forms.ToolStrip)(printPreviewDialog.Controls[1])).ImageList.Images[0];
			this.ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.ToolStripButton.Click += new System.EventHandler(this.printPreview_PrintClick);
			((System.Windows.Forms.ToolStrip)(printPreviewDialog.Controls[1])).Items.RemoveAt(0);
			((System.Windows.Forms.ToolStrip)(printPreviewDialog.Controls[1])).Items.Insert(0, ToolStripButton);
		}
		private void printPreview_PrintClick(object sender, System.EventArgs ee)
		{
			try
			{
				this.printDialog.Document = printDocument;
				if (printDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				{
					printDocument.Print();
				}
			}
			catch (System.Exception ex)
			{
				System.Windows.MessageBox.Show(ex.Message, ToString());
			}
		}
		private System.Windows.Forms.ToolStripButton ToolStripButton;
