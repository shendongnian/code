    for (int i = 0; i < 10; i++)
    {
        DataRow dr = dt.NewRow();
        dr["Sr.No"] = i + 1;
        dr["Column1"] = string.Empty;
        dr["Column2"] = string.Empty;
        dr["Column3"] = string.Empty;
        dr["Column4"] = string.Empty;
    
        dt.Rows.Add(dr);
    }
