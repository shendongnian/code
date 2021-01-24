     List<string> values = new List<string>()
     foreach (ListItem item in chkLeaveType.Items)
     {
         if (item.Selected)
            values.Add("'" + item.Value + "'");
     }
     DataRow[] rows = null;
     // Consider that you should also handle the no selection status
     if(values.Count == 0)
        rows = dt.Select();   // ??
     else
        rows = dt.Select("LeaveType IN (" + 
                      string.Join(",", values.ToArray() + ")");
