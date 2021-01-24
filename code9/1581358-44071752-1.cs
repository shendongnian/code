    protected void btnGetData_Click(object sender, EventArgs e)
            {
                GetData();
            }
    
            private void GetData()
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Connection String";
    
                string Query = string.Empty;
                if (ddlQuery.SelectedValue == "1")
                    Query = "SELECT * FROM Table1";
                else if (ddlQuery.SelectedValue == "2")
                    Query = "SELECT * FROM Table2";
                else if (ddlQuery.SelectedValue == "3")
                    Query = "SELECT * FROM Table3";
    
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = Query;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
    
                    DataTable dtFinal = new DataTable();
                    foreach (DataColumn cln in dt.Columns)
                    {
                        dtFinal.Columns.Add(cln.ColumnName + " " + txtAlias.Text, cln.DataType);
                    }
                    foreach (DataRow row in dt.Rows)
                    {
                        DataRow dr = dtFinal.NewRow();
                        for (int i = 0; i < dtFinal.Columns.Count; i++)
                        {                       
                            dr[i] = row[i];                        
                        }
                        dtFinal.Rows.Add(dr);
                    }
                    gcData.DataSource = dtFinal;
                    gcData.DataBind();
                }
                catch (Exception)
                {
                    throw;
                }
    
            }
