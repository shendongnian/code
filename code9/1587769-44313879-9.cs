	private void richTextBox1_SelectionChanged(object sender, EventArgs e)
	{
		if (richTextBox1.SelectedText.Length > 0)
		{
			Point relativePoint = rTxtBxSelectionTester.GetPositionFromCharIndex(rTxtBxSelectionTester.SelectionStart);
            relativePoint = new Point(relativePoint.X + rTxtBxSelectionTester.Location.X, relativePoint.Y + rTxtBxSelectionTester.Location.Y); //Adapt the RichTextBox offset 
            this.buttonOverlay.Location = relativePoint;
            this.buttonOverlay.Visible = true;
            this.buttonOverlay.BringToFront();			
		}
		else
		{
			this.buttonOverlay.Visible = false;
		}
	}
