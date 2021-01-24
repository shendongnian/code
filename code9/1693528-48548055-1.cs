    // Word with specified color to which add a symbol
    var searchedColor = Color.Red;
    // Reset selection
    richTextBox1.SelectionStart = 0;
    richTextBox1.SelectionLength = 0;
    // Symbol to add to the word
    const string symbol = "!";
    // List of words, maybe you want to use a custom separator
    var words = richTextBox1.Text.Split(' ');
    int index = -1;
    foreach (var word in words)
    {
        while ((index = richTextBox1.Text.IndexOf(word, (index + 1))) != -1)
        {
            richTextBox1.Select((index), word.Length);
            // If the selected text as the specified color
            if (richTextBox1.SelectionColor == searchedColor)
            {
                //Add the symbol
                richTextBox1.SelectedText = word + symbol;
            }
        }
    }
