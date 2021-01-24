        public void ImportExcel(string FilePath)
        {
            string ConnStr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + FilePath + ";Extended Properties=\"Excel 12.0 Xml;HDR=YES\";";
                        OleDbConnection Conn = new OleDbConnection(ConnStr);
            OleDbDataAdapter DA = new OleDbDataAdapter("select * from [Sheet1$]", Conn);
            DA.Fill(dt);
            DGV_Data.DataSource = dt;
            //Calculate record counts
            L_Rows_Count.Text = "Count: " + (DGV_Data.Rows.Count - 1).ToString("n0");
            Conn.Close();
        }
