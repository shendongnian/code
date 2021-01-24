    if (chkLineBreaks.Checked)
    {
        var lines = txtInput.Lines;
        for (int i = 0; i < lines.Length; i++)
        {
            outputStringBuilder.Append($@"'{lines[i]}',");
        }
    }
