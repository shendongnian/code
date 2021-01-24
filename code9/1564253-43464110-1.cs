    // Start our helper class with 'Regular' font
    TextHelper.CurrentStyle = FontStyle.Regular;
    var html = new StringBuilder();
    for (int index = 1; index <= cell.Text.ToString().Length; index++)
    {
        char ch = cell.get_Characters(index, 1);
        // If the Font of this character is different than the current font, 
        // this will close the old style and open our new style.
        html.Append(TextHelper.ChangeStyleIfNeeded(ch.Font));
                    
        // Append this character
        html.Append(ch.Text);
    }
    // Close the style at the very end
    html.Append(TextHelper.CloseTag);
