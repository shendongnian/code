    foreach (var line in File.ReadLines("file path"))
    {
        if (line.EndsWith(myWord))
        {
            outputEmails.Text += line + Environment.NewLine;
        }
    }
