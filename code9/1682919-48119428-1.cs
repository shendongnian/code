    String[] lines = ...
    foreach (String line in lines)
    {
        box.SelectionStart = box.TextLength;
        box.SelectionLength = 0;
        if (line.StartsWith("#"))
            box.SelectionColor = Color.Red;
        else
            box.SelectionColor = Color.Black;
        box.AppendText(line + Environment.NewLine);
    }
