                DataTable dt = new DataTable();
                dt.Columns.Add("Program", typeof(string));
                dt.Columns.Add("Version", typeof(double));
                dt.Columns.Add("InstallDate", typeof(DateTime));
                dt.Columns.Add("Company", typeof(string));
                dt.Columns.Add("InstallLocation", typeof(string));
                dt.Columns.Add("Size", typeof(long));
    
                foreach (ManagementObject queryObj in searcher8.Get())
                {
                    var newRow = dt.NewRow();
                    newRow["Program"] = queryObj["Description"];
                    newRow["Version"] = queryObj["Version"];
                    newRow["InstallDate"] = FormatDateTime(queryObj["InstallDate"]);
                    newRow["Company"] = queryObj["Vendor"];
                    newRow["InstallLocation"] = queryObj["InstallLocation"];
                    newRow["Size"] = ObterTamanhoDiretorio(queryObj["InstallLocation"]);
                    
                    dt.Rows.Add(newRow);
                }
    
                dataGridView1.DataSource = dt;
