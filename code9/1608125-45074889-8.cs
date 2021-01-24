    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow || (e.Row.RowState & DataControlRowState.Edit) > 0)
            {
                CheckBoxList chklist = ((CheckBoxList)e.Row.FindControl("CheckBoxList1"));
                string subjects = ((Label)e.Row.FindControl("Label6")).Text;
                string[] subjectslist = subjects.Split(',');
                foreach (string item in subjectslist)
                {
                    if (item == "Physics")
                        chklist.Items.FindByText("Physics").Selected = true;
                    else if (item == "Chemistry")
                        chklist.Items.FindByText("Chemistry").Selected = true;
                    else
                        chklist.Items.FindByText("Biology").Selected = true;
                }
            }
        }
