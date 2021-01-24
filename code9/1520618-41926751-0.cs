         int max = dgv.Rows.Count;
     DataGridViewCellStyle style;
                for (int i = 0; i < max; i++)
    
                    for (int j = 2; j < dgv.Columns.Count; j++)
    
                        if (dgv[j, i].Value.ToString() == "")
                        {
                            style = dgv[j, i].Style;
                            style.BackColor = Color.Red;
                            dgv[j, i].Style = style;
                        } 
