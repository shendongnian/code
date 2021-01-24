    private void BindDynaicGrd()
        {
            //instance of a datatable
            DataTable dt = new DataTable();
            //instance of a datarow
            DataRow drow;
            //creating two datacolums dc1 and dc2 
            DataColumn dc1 = new DataColumn("Code", typeof(string));
            DataColumn dc2 = new DataColumn("Name", typeof(string));
            //adding datacolumn to datatable
            dt.Columns.Add(dc1);
            dt.Columns.Add(dc2);
           
            if (grd.Rows.Count > 0)
            {
                foreach (GridViewRow gvr in grdSites.Rows)
                {
                   
                    CheckBox chk_Single = (CheckBox)gvr.FindControl("chkSingle");
                    if (chk_Single.Checked == true)
                    {
                        Label lbl_SiteCode = (Label)gvr.FindControl("lblCode");
                        Label lbl_SiteName = (Label)gvr.FindControl("lblName");
                        //instance of a datarow
                        drow = dt.NewRow();
                        //add rows to datatable
                        //add Column values
                        drow = dt.NewRow();
                        drow["Code"] = lbl_SiteCode.Text;
                        drow["Name"] = lbl_SiteName.Text.ToString();
                        dt.Rows.Add(drow);
                    }
                }
            }
            //set gridView Datasource as dataTable dt.
            gridcl.DataSource = dt;
            //Bind Datasource to gridview
            gridcl.DataBind();
        }
