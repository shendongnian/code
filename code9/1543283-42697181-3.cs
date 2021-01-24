	DataTable dt = new DataTable();
	dt.TableName = "NTB_EIM_O365";
	sda.Fill(dt);
    if(dt.Rows.Count == 0)
        return null;
    // check the first row:
    bool allEmpty = true;
    for (int columnIndex = 0; columnIndex < dt.Columns.Count; columnIndex++)
    {
        if (!string.IsNullOrEmpty(dt.Rows[0][columnIndex].ToString()))
        {
            allEmpty = false;
            break;
        }
    }
    
    if(allEmpty)
        return null;
	return dt;
