    string[]  lines = richTextBox2.Lines;
    
    for (int i = 0; i < lines.Length; i++)
    {
    	lines[i] = (i+1) + " " + lines[i];
    }
    richTextBox2.Lines = lines;
