    string stringComparision = "";
    for(int i = 0; i < listBox1.SelectedItems.Count; i++)
    {
       DataRowView dr = listbox1.SelectedItems[i] as DataRowView;
       stringComparision += "'" + dr["TerritoryName"].ToString() + "',";
    }
    stringComparision = stringComparision.TrimEnd(','); // to delete last comma
