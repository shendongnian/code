        protected void gv_TT_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "delRow")
            {
                //get the id from the button and covert it
                int itemID = Convert.ToInt32(e.CommandArgument);
                //cast the viewstate as a datatable
                DataTable dt = ViewState["GridViewTable"] as DataTable;
                //filter out the row with the itemID to be deleted with Linq
                DataTable dtFiltered = dt.AsEnumerable().Where(row => row.Field<int>("itemID") != itemID).CopyToDataTable();
                //set the viewstate with the filtered datatable
                ViewState["GridViewTable"] = dtFiltered;
                //rebind the grid
                GridView1.DataSource = dtFiltered;
                GridView1.DataBind();
            }
        }
