    private static float GetTextHeightUntilIndex(TextBox textBox, int index)
    	{
    		var height = 0;
    		var textBuffer = textBox.Text;
    		
    		// Remove everything after `index` in order to measure its size
    		textBox.Text = textBuffer.Substring(0, index);
    		textBox.Measure(new Size(Double.PositiveInfinity, Double.PositiveInfinity));
    		var height = textBox.DesiredSize().Height;
    		
    		// Put the full text back
    		textBox.Text = textBuffer;
    		
    		return height;
    	}
    
    private void Find(string text)
        {
            textarea.Focus(FocusState.Programmatic);
            var start = textarea.SelectionStart + textarea.SelectionLength;
            var found =  (bool)checkboxFindCaseSensitive.IsChecked ? textarea.Text.IndexOf(text, start) : textarea.Text.IndexOf(text, start, StringComparison.CurrentCultureIgnoreCase);
            if (found == -1)
            {
                textarea.SelectionStart = 0;
                found = (bool)checkboxFindCaseSensitive.IsChecked ? textarea.Text.IndexOf(text, start) : textarea.Text.IndexOf(text, start, StringComparison.CurrentCultureIgnoreCase);
                if (found == -1) return;
            }
            textarea.SelectionStart = found;
            textarea.SelectionLength = text.Length;
    		// -------------------
            var cursorPosInPx = GetTextHeightUntilIndex(textarea, found);
            // First method: resize your textbox to the selected word:
    		textarea.Height = cursorPosInPx; 
            // Second method: scroll to your textbox
            var grid = (Grid)VisualTreeHelper.GetChild(textarea, 0);
            for (var i = 0; i <= VisualTreeHelper.GetChildrenCount(grid) - 1; i++)
            {
	            object obj = VisualTreeHelper.GetChild(grid, i);
	            if (obj is ScrollViewer)
		            ((ScrollViewer)obj).ChangeView(null, cursorPosInPx, null, true);
            }
        }
