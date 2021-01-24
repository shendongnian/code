    protected void OracleView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            string sql = "select Concern.name from Concern";
    
           /*here your connection and method read list*/
            List<string> ls = new List<string>();
            ls = return your list data;
            //ls.Insert(0, String.Empty);
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var ddl = e.Row.FindControl("ConcernList") as DropDownList;
                if (ddl != null)
                {
                    ddl.DataSource = ls;
                    ddl.SelectedValue = YourSelectedValueFromAnotherTable;
                    ddl.DataBind();
                    listDropdownMark = ls;
                    selectedMeltDropdown = YourSelectedValueFromAnotherTable;
                }
    
            }
    
        }
