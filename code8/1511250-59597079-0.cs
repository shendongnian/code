    using (var ew = new ExcelWriter("C:\\temp\\test.xlsx"))
    {
        ew.Write("ID", 1, 1);
        ew.Write("Name", 2, 1);
        ew.Write("1", 1, 2);
        ew.Write("One", 2, 2);
        ew.Write("2", 1, 3);
        ew.Write("Two", 2, 3);
    }
