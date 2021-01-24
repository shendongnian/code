    static void Main(string[] args)
    {
        // Using an OleDbConnection to connect to excel
        var cs = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={@"C:\AAAA\Report.xlsx"};Extended Properties=""Excel 12.0 Xml; HDR = Yes; IMEX = 2"";Persist Security Info=False";
        var con = new OleDbConnection(cs);
        con.Open();
    // Using OleDbCommand to read data of the sheet(sheetName)
    var cmd = new OleDbCommand($"select * from [Sheet1$]", con);
    var ds = new DataSet();
    var da = new OleDbDataAdapter(cmd);
    da.Fill(ds);
       // Convert DataSet to Xml
    using (var fs = new FileStream(@"C:\Users\MT2362\Downloads\CRS_XML.xml", FileMode.CreateNew))
    {
        using (var xw = new XmlTextWriter(fs, Encoding.UTF8))
        {
            ds.WriteXml(xw);
        }
    }
         XDocument doc = XDocument.Load("C:\Users\MT2362\Downloads\CRS_XML.xml");
    Test_XSD test_XSD = Utility.FromXml<Test_XSD>(doc.Document.ToString()); 
    XSD xsd = new XSD();
    xsd.version = "TEST VERSION";
    Console.WriteLine(xsd.version);
    Console.ReadKey();
    }
