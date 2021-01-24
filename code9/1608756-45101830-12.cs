    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {
                    CheckBoxList chklist = ((CheckBoxList)e.Row.FindControl("CheckBoxList1"));
                    string subjects = ((Label)e.Row.FindControl("lblSubjects")).Text;
                    List<string> studentsubjects = subjects.Split(',').ToList();
                    foreach (string item in studentsubjects)
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
        }
