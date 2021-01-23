    // Gets the number of newline characters in your rich text box
    var numberOfNewLines = richTextBox1.Text.Count(r => r == '\n');
    for (var i = 0; i < numberOfNewLines; i++)
    {
         // Finds the first occurance of the newline character
         var newlineCharacterIndex = richTextBox1.Text.IndexOf('\n') + 1;
         // Replaces the rich textbox text with everything but the above line
         richTextBox1.Text = richTextBox1.Text.Substring(newlineCharacterIndex);
         MessageBox.Show("OK!");
    }
    // Removes the final line.
    richTextBox1.Text = string.Empty;
