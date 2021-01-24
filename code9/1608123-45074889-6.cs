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
                        chklist.SelectedItem.Text = "Physics";
                    else if (item == "Chemistry")
                        chklist.SelectedItem.Text = "Chemistry";
                    else
                        chklist.SelectedItem.Text = "Biology";
                }
            }
        }
