    static void Main(string[] args)
    {
        using (var pck = new ExcelPackage(new FileInfo(@"c:\temp\Book1.xlsm")))
        {
            pck.Save();
        }
    }
