    var lines = File.ReadAllLines(openFile.FileName);
    var words = lines
        .Select(line => line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries))
        .SelectMany(w => w)
        .Distinct();
    thisTextBox.Text = string.Join(Environment.NewLine, words);
