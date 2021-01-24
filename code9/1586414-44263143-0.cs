    public static IEnumerable Data()
    {
        var rows = ReadExcel("testdata.xlsx");
        return rows.Select(row => new TestCaseData(row[0], row[1]));
    }
