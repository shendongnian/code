    public static System.Data.DataTable GetcsvExcelRecords(string csvPath, string CSVFileName)
    {
        string modCSVFileName = CreateFileRemovingFirstLine(csvPath, CSVFileName);
        string[] workSheetNames = new string[] { };
        System.Data.DataTable dtExcelData = new System.Data.DataTable();
        string SourceConstr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + csvPath + "';Extended Properties='Text;HDR=Yes;FMT=Delimited;'";
        using (OleDbConnection excelConn = new OleDbConnection(SourceConstr))
        {
            excelConn.Open();
            OleDbCommand excelCommand = new OleDbCommand();
            OleDbDataAdapter excelDataAdapter = new OleDbDataAdapter();
            excelCommand = new OleDbCommand("SELECT * FROM [" + modCSVFileName + "]", excelConn);
            excelDataAdapter.SelectCommand = excelCommand;
            excelDataAdapter.Fill(dtExcelData);
            return dtExcelData;
        }
    }
    private static string CreateFileRemovingFirstLine(string csvPath, string CSVFileName)
    {
        string filePath = Path.Combine(csvPath, CSVFileName);
        string modifiedFileName = CSVFileName.Replace(".csv", "2.csv");
        using (StreamReader sr = new StreamReader(filePath))
        {
            string headerLine = sr.ReadLine();
            string str = sr.ReadToEnd();
            // use the appropriate encoding... for example I am using ASCII
            byte[] buffer = Encoding.ASCII.GetBytes(str);
            MemoryStream ms = new MemoryStream(buffer);
            // write to file... check for access permission to create file
            FileStream file = new FileStream(Path.Combine(csvPath, modifiedFileName), FileMode.Create, FileAccess.Write);
            ms.WriteTo(file);
            file.Close();
            ms.Close();
        }
        return modifiedFileName;
    }
