    foreach (DataGridViewRow row in JadwalisiGV.Rows)
        {
            if (!row.IsNewRow)
            {
            kon2.Open();    
            comm.CommandText = "SELECT * FROM [Data$] WHERE [WSID] = '"+    row.Cells["WSID"].Value +"'";
            row.HeaderCell.Value = (row.Index + 1).ToString();
            listBox1.Items.Add(); // I want to show row number of my WSID data that is shown in JadwalisiGV here
            kon2.Close();
    
            }
        }
