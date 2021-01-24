    public static void Main(string[] args)
    {
        WriteExcelService writeExcelService = new WriteExcelService();
        Dictionary<string, List<string>> contentList = new Dictionary<string, List<string>>
    {
        { "en-US",new List<string> (new string[] { "Dummy text 01","Dummy text 02"}) },
        { "es-ES",new List<string> (new string[] { "Texto ficticio 01", "Texto ficticio 02"}) }
    };
        string inputFile = @"C:\{username}\Desktop\Valentines_Day.xlsx";
        string sheetName = "Copy";
        writeExcelService.WriteValueToCell(inputFile, sheetName, contentList);
}
