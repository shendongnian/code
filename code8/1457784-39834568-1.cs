      DataTable dt = new DataTable();
                dt.Columns.Add("ID", Type.GetType("System.String"));
                dt.Columns.Add("Path", Type.GetType("System.String"));
                dt.Columns.Add("Name", Type.GetType("System.String"));
                for (int i = 0; i < length; i++)
                {
                    dt.Rows.Add();
                    dt.Rows[dt.Rows.Count - 1]["ID"] = array[i][0];
                    dt.Rows[dt.Rows.Count - 1]["Path"] = array[i][1];
                    dt.Rows[dt.Rows.Count - 1]["Name"] = array[i][2];
                }
                Grid.DataSource = dt;
                Grid.DataBind(); 
