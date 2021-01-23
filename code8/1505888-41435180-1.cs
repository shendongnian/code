    var lines = File.ReadLines(txtFilePath.Text).Where(x => IsBetweenDates(x)).ToList();
    private bool IsBetweenDates(string x)
    {
        var value = x.Split((char)9)[1];
        return value >= fromDate && value <= toDate;
    }
