     List<string> values = new List<string>()
     foreach (ListItem item in chkLeaveType.Items)
     {
         if (item.Selected)
            values.Add("'" + item.Value + "'");
     }
     DataRow[] rows = dt.Select("LeaveType IN (" + 
                      string.Join(",", values.ToArray() + ")");
