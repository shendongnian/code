    string[]  lines = richTextBox2.Lines;
    
    for (int i = 0; i < lines.Length; i++)
    {
    	lines[i] = i + " " + lines[i];
    }
    richTextBox2.Lines = lines;
