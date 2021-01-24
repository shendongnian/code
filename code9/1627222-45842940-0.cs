    var uniqueItems = new HashSet<string>();
    foreach (Excel.Range cell in xlRng)
    {
        var cellText = (string)cell.Text;
        foreach (var item in cellText.Split(',').Select(s => s.Trim()))
        {
            uniqueItems.Add(item);
        }
    }
    foreach (var item in uniqueItems)
    {
        Console.WriteLine(item);
    }
