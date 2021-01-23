      if (!this.IsPostBack)
                {   DataTable dt = new DataTable();
                    dt.Columns.Add("0");
                    dt.Columns.Add("1");
                    dt.Columns.Add("2");
                    dt.Columns.Add("3");
                    dt.Columns.Add("4");
    
                    DataRow dr = dt.NewRow();
                    dr[0] = "12-12-12"; //Error message occured here
                    dr[1] = "Jeddah";
                    dr[2] = "Java";
                    dr[3] = "2";
                    dr[4] = "View Details";
    
                    dt.Rows.Add(dr);
                    GridViewRecord.DataSource = dt;
                    GridViewRecord.DataBind();
                }
