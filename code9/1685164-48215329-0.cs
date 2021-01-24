    bool columnsAdded = false;
    foreach (GridViewRow row in gridviewmain.Rows)
    {
        CheckBox chk = (CheckBox)row.Cells[0].FindControl("checkboxforcode");
        if (chk.Checked == true)
        {
            if (!columnsAdded )
            {
                for (int i = 0; i < gridviewmain.Columns.Count; i++)
                {
                    datatablefirst.Columns.Add("column" + i.ToString());
                }
                columnsAdded = true;
            }
            DataRow dr = datatablefirst.NewRow();
            for (int j = 0; j < gridviewmain.Columns.Count; j++)
            {
                dr["column" + j.ToString()] = row.Cells[j].Text;
            }
            datatablefirst.Rows.Add(dr);
        }
    }
