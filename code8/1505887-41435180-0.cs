    var lines = File.ReadLines(txtFilePath.Text).Where(x => IsBetweenDates).ToList();
    private bool IsBetweenDates(string value)
    {
        var value = x.Split((char)9)[1];
        return value >= fromDate && value <= toDate;
    }
