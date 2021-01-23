    private void SetPreviousData()
        {
            int rowIndex = 0;
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < (dt.Rows.Count - 1); i++)
                    {
                        DropDownList ddl1 = (DropDownList)Gridview1.Rows[rowIndex].Cells[1].FindControl("EqpCatDDL");
                        DropDownList ddl2 = (DropDownList)Gridview1.Rows[rowIndex].Cells[2].FindControl("DescripDDL");
                        TextBox box3 = (TextBox)Gridview1.Rows[rowIndex].Cells[3].FindControl("TextBox3");
                        TextBox box4 = (TextBox)Gridview1.Rows[rowIndex].Cells[4].FindControl("TextBox4");
                        ddl1.SelectedValue = dt.Rows[i]["Column1"].ToString();
                        string connString = ConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString;
                        SqlConnection connection = new SqlConnection(connString);
                        SqlCommand cmd2 = new SqlCommand(""SELECT Description FROM EqpCategory WHERE EqpCat = '" + Convert.ToInt32(ddl1.SelectedValue) + "'", connection);
                        cmd2.Connection.Open();
                        SqlDataReader ddlValues2;
                        ddlValues2 = cmd2.ExecuteReader();
                        ddl2.DataTextField = "Description";
                        ddl2.DataValueField = "Description";
                        ddl2.DataSource = ddlValues2;
                        ddl2.DataBind();
                        cmd2.Connection.Close();
                        cmd2.Connection.Dispose();
                        ddl2.SelectedValue = dt.Rows[i]["Column2"].ToString();
                        box3.Text = dt.Rows[i]["Column3"].ToString();
                        box4.Text = dt.Rows[i]["Column4"].ToString();
                        rowIndex++;
                    }
                }
            }
        }
