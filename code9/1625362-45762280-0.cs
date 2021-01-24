    CheckBoxList projects = (CheckBoxList)GridView1.Rows[e.RowIndex].FindControl("CheckBoxList1");
    List<string> projectsList = new List<string>();
    string expression = "";
    foreach (ListItem item in projects.Items)
    {
        if (item.Selected)
            projectsList.Add(item.Text);
    }
    expression = string.Join(",", projectsList); // add , inside projects (InProgress,Pending,Complete)
