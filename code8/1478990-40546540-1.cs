    string Id = "";
    
    ds_utilityTableAdapters.tbl_membersTableAdapter tam = new ds_utilityTableAdapters.tbl_membersTableAdapter();    
    ds_utility.tbl_membersDataTable dtm = new ds_utility.tbl_membersDataTable();
    List<string> idList = new List<string>();
    
    foreach (DataGridViewRow row in dgv_members.Rows)    
    {        
        if (row.Cells[0].Value != null && (Boolean)row.Cells[0].Value == true)
        {
            Id= row.Cells[1].Value.ToString();
    
            // using Id to display data in crystal report viewer  
            // but only read the latest checkbox value
    
    	idList.Add(Id);
        }
    }
    
    dtm = tam.GetDataBy_SearchId(string.Join(",", idList));
    
            
