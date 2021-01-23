    DataTable dtSessionTable = (DataTable)Session["PolicyTable"];
    
    foreach (DataRow item in dtSessionTable.Rows)
    {
        cellVal = item["Policy_No"].ToString();
        ds = db.insertPolicyDetails(cellVal);
    }
