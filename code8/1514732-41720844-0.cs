        string fileName = @"glid.csv";
        DataSet ds = new DataSet("csvData");
        string dir = Path.GetDirectoryName(fileName);
        string connstr = String.Format("Provider = Microsoft.Jet.OleDb.4.0; Data Source = { 0 }; Extended Properties = \"Text;HDR=YES;FMT=Delimited\"",dir);
        using (System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection())
        {
            conn.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM " + Path.GetFileName(fileName), conn);
            adapter.Fill(ds);
        }
        var p = ds; //<-- here is your data;
