    List<int> list = new List<int>(); 
        if (ViewState["SelectedRecords"] != null) 
        { 
            list = (List<int>)ViewState["SelectedRecords"]; 
        } 
        foreach (GridViewRow row in GridView1.Rows) 
        { 
            CheckBox chk = (CheckBox)row.FindControl("chkSelect"); 
            var selectedKey = 
            int.Parse(GridView1.DataKeys[row.RowIndex].Value.ToString()); 
            if (chk.Checked) 
            { 
                if (!list.Contains(selectedKey)) 
                { 
                    list.Add(selectedKey); 
                } 
            } 
            else 
            { 
                if (list.Contains(selectedKey)) 
                { 
                    list.Remove(selectedKey); 
                } 
            } 
        } 
        ViewState["SelectedRecords"] = list; 
        //BindGrid(); 
    }
