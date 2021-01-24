    while (dataReader1.Read())
    {
        string[] newRow = new string[] { dataReader1["columnA"].ToString(),     dataReader1["columnB"].ToString(), dataReader1["columnC"].ToString() };
        Boolean found = false;
        foreach (DataGridViewRow row in dgData.Rows)
        {
             if (row.Cells[0].Value == dataReader1["columnA"].ToString())
             {
                  // row exists
                  found = true;
                  MessageBox.Show("Row already exists");
                  break;                   
             }
        }
    
        if (!found)
        {
             dgData.Rows.Add(newRow);
        }
    }
