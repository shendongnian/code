    var lines = File.ReadAllLines(openFile.FileName);
    var words = lines
        .SelectMany(line => line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries))
        .Distinct();
    thisTextBox.Text = string.Join(Environment.NewLine, words);
