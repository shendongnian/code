    Stopwatch sw = new Stopwatch();
    sw.Start();
    DataSet excelDataSet = new DataSet();
    
    string filePath = @"c:\temp\BigBook.xlsx";
    
    // For .XLSXs we use =Microsoft.ACE.OLEDB.12.0;, for .XLS we'd use Microsoft.Jet.OLEDB.4.0; with  "';Extended Properties=\"Excel 8.0;HDR=YES;\"";
    string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + filePath + "';Extended Properties=\"Excel 12.0;HDR=YES;\"";
    
    using (OleDbConnection conn = new OleDbConnection(connectionString))
    {
        conn.Open();
        OleDbDataAdapter objDA = new System.Data.OleDb.OleDbDataAdapter
        ("select * from [Sheet1$]", conn);
        objDA.Fill(excelDataSet);
        //dataGridView1.DataSource = excelDataSet.Tables[0];
    }
    sw.Stop();
    Debug.Print("Load XLSX tool: " + sw.ElapsedMilliseconds + " millisecs. Records = "  + excelDataSet.Tables[0].Rows.Count);
            
