	var thisFile = File.ReadAllLines(openFile.FileName);
	var theseWords = new List<List<string>>();
	foreach (var line in thisFile)
	{
		var split = line.Split(new[] { ' ', '\t' },
		StringSplitOptions.RemoveEmptyEntries);
		theseWords.Add(split.ToList());
	}
	thisTextBox.Text = String.Join(Environment.NewLine, String.Join(" ", theseWords));
