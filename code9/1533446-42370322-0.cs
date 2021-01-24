            try
            {
                OleDbConnection conn = new OleDbConnection();
                conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\kanndeva\\Documents\\Visual Studio 2015\\Projects\\DVC_ProjTool\\Project.xlsx; Extended Properties=Excel 12.0 XML;";
                conn.Open();
                OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM [Sheet1$]", conn);
                DataTable ds = new DataTable();
                da.Fill(ds);
                stdCombo.Text = "--Select--";
                for (int i = 0; i < ds.Rows.Count; i++)
                {
                    stdCombo.Items.Add(ds.Rows[i]["pmName"]);
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetBaseException().ToString(), "Error In Connection");
            }
