    //temp file path
    string tempDbPath = System.AppDomain.CurrentDomain.BaseDirectory.ToString();
    //temp db file name
    string tempDbFile = "tempdb.xlsx";
    //path + filename
    string tempDBLocation = Path.Combine(tempDbPath, tempDbFile);
    //get byte array from application's resources
    byte[] resourceBytes = Properties.Resources.DataBase;
    
    //write all bytes to specified location
    File.WriteAllBytes(tempDBLocation, resourceBytes);
    
    //connect and select data as usual
    string constr = String.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=""Excel 12.0 Xml;HDR=NO""", tempDBLocation);
    using (OleDbConnection conn = new OleDbConnection(constr))
    {
    	conn.Open();
    	OleDbCommand command = new OleDbCommand(string.Format("Select * from [{0}]", "Sheet1$"), conn);
    	OleDbDataReader reader = command.ExecuteReader();
    }
    
    //delete temp file
    File.Delete(tempDBLocation);
