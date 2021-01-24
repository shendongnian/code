        public void lastRecordTable()
        {
            if (Session["lastRecord"] == null)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("1");
                dt.Columns.Add("2");
                dt.Columns.Add("3");
                dt.Columns.Add("4");
                Session["lastRecord"] = dt;
                GridView1.DataSource = dt;
                GridView1.DataBind();           
            }
            else
            {
                DataTable dt = (DataTable)Session["lastRecord"];
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }  
