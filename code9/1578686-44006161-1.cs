            private System.Data.DataTable GetDataFromSharePointWithFilter(System.Uri Link, string ListName)
        {
            #region GetDataFromSharePoint
            string connectionString = GenerateConnectionString(Link, ListName);
            System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection(connectionString);
            conn.Open();
            string strSQL = "SELECT * FROM LIST";
            System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDbCommand(strSQL, conn);
            DataSet ds = new DataSet();
            
            ds.Locale = System.Globalization.CultureInfo.InstalledUICulture;
            System.Data.OleDb.OleDbDataAdapter da = new System.Data.OleDb.OleDbDataAdapter(cmd);
            da.Fill(ds);
            #endregion
            #region Transfer data to DataTable
            return ds.Tables[0];
            #endregion
            }
