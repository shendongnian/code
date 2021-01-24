    for (int i = 0; i < size; i++)
    {
        richTextBox1.AppendText("[" + i.ToString() + "]" + "  " + plik[i] + Environment.NewLine);
        richTextBox1.Select(richTextBox1.GetFirstCharIndexFromLine(i), richTextBox1.Lines[i].Length);
        richTextBox1.SelectionBackColor = plik[i][plik[i].Length - 1] == 'n' ? Color.Red : Color.Green;
    }
