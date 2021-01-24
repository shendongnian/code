        private void SetInitialRow()
        {
            DataTable dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add(new DataColumn("Sr.No", typeof(string)));
            dt.Columns.Add(new DataColumn("Column1", typeof(string)));
            dt.Columns.Add(new DataColumn("Column2", typeof(string)));
            dt.Columns.Add(new DataColumn("Column3", typeof(string)));
            dt.Columns.Add(new DataColumn("Column4", typeof(string)));
            for (int i = 0; i < 10; i++)
            {
                dr = dt.NewRow();
                dr["Sr.No"] = (i +1);
                dr["Column1"] = string.Empty;
                dr["Column2"] = string.Empty;
                dr["Column3"] = string.Empty;
                dr["Column4"] = string.Empty;
                dt.Rows.Add(dr);
            }
            
            //Store the DataTable in ViewState
            ViewState["CurrentTable"] = dt;
            griditem.DataSource = dt;
            griditem.DataBind();
        }
