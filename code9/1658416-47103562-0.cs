    public IEnumerable<ResultantRead> processCSVFile()
    {
        var alist = File.ReadLines("C:/Users")
                        .Skip(54);
                        .Select(v => ResultantRead.readCsv(v));
        return alist;
    }
    //calling code
    var result = processCSVFile().Take(5).ToList();
    // result will only enumerate 59 rows (or less) from the file
