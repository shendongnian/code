    //create a list to store all the subjects
    List<string> studentsubjects = new List<string>();
    //find the control in the GridView and cast it back to a CheckBoxList
    CheckBoxList subjects = GridView1.Rows[e.RowIndex].FindControl("CheckBoxList1") as CheckBoxList;
    
    //loop all the items and see if they are checked
    foreach (ListItem item in subjects.Items)
    {
        if (item.Selected)
        {
            //add the checked value to the list
            studentsubjects.Add(item.Text);
        }
    }
    //display results
    Label1.Text = string.Join(",", studentsubjects);
