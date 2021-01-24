    List<string> queryEventIDList;
    foreach (ListItem lstAssign in lstEvent.Items)
    {
        if (lstAssign.Selected == true)
        {
            queryEventIDList.Add(lstAssign.Value);                 
            logfield = logfield + "," + lstEvent.SelectedItem.Text;
        }
    }
    string queryEventIDs = string.Join(",", queryEventIDList);
