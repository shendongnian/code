            string queryEventID = "";
            foreach (ListItem lstAssign in lstEvent.Items)
            {
                if (lstAssign.Selected == true)
                {
                    queryEventID = queryEventID + lstAssign.Value + " "; //queryEventID(234 229)                   
                    logfield = logfield + "," + lstEvent.SelectedItem.Text;
                }
            }
            string queryEventIDs = string.Join(",", queryEventID.Split(' '));
