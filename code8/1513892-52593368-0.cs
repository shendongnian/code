     OpenFileDialog opener = new OpenFileDialog();
       opener.Filter = "Excel Files| *.xlsx;*.xls;*.csv;";
    if (opener.ShowDialog() == DialogResult.Cancel)
        return;
    
    FileStream streamer = new FileStream(opener.FileName, FileMode.Open);
    IExcelDataReader reader;
    if (Path.GetExtension(opener.FileName) == ".xls")
    {
        reader = ExcelReaderFactory.CreateBinaryReader(streamer);
    }
    else if (Path.GetExtension(opener.FileName) == ".csv")
    {
    
       var reader = ExcelReaderFactory.CreateReader(stream, new ExcelReaderConfiguration() {
	// Gets or sets the encoding to use when the input XLS lacks a CodePage
	// record, or when the input CSV lacks a BOM and does not parse as UTF8. 
	// Default: cp1252. (XLS BIFF2-5 and CSV only)
	FallbackEncoding = Encoding.GetEncoding(1252),
	
	// Gets or sets the password used to open password protected workbooks.
	Password = "password",
	// Gets or sets an array of CSV separator candidates. The reader 
	// autodetects which best fits the input data. Default: , ; TAB | # 
	// (CSV only)
	AutodetectSeparators = new char[] { ',', ';', '\t', '|', '#' };
    });
        }
        else
        {
            reader = ExcelReaderFactory.CreateOpenXmlReader(streamer);
        }
        DataSet results = reader.AsDataSet();
        results.Tables[0].Rows[0].Delete();
        results.AcceptChanges();
        
        
        foreach (System.Data.DataTable table in results.Tables)
        {
            foreach (DataRow dr in table.Rows)
            {
               >>> Do Something With the Data
            }
        }
