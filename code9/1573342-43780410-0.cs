    public void WriteData(string colName, string data)
    {
        using (OleDbConnection cn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Constants.FileName + ";Extended Properties=\"Excel 8.0;HDR=NO;IMEX=3;READONLY=FALSE\""))
        {
            string query = string.Format("INSERT INTO [DataSet$] ({0}) VALUES (@data)", colName);
            // The query variable will have following value assuming colName=token
            //INSERT INTO [DataSet$] (token) VALUES (@data)
            cn.Open();
            //Now use OleDbCommand to pass value of @data to the query.
            OleDbCommand cmd = new OleDbCommand(query, cn);
            cmd.Parameters.AddWithValue("@data", data);
            cmd.ExecuteNonQuery();
            cn.Close();
        }
    }
