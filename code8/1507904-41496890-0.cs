    while (sdr.Read())
    {
         ListItem item = new ListItem();
         item.Text = sdr["Lastname"].ToString() + ' ' + sdr["Firstname"].ToString();
         item.Value = sdr["ID"].ToString();
        if (xxx ==yyy)
        {                        
            item.Selected = true;
        }
        ddlCrew.Items.Add(item);
    }
