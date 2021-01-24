    private void addExtraRows(DataTable dT)
    {
    
        DataTable newTable = dT.Clone();
        DataRow nR;
        int lastRow = dT.Rows.Count - 1;
        for (int i = 0; i < lastRow; i++)
        {
            if (dataGridView3.Rows[i].Cells[1].Value.ToString() == "1.1")
            {
                for (int j = i + 1; j < dT.Rows.Count; j++)
                {
                    if (dT.Rows[j][2] == dT.Rows[i][2] && dT.Rows[j][3] == dT.Rows[i][3])
                    {
                        nR = newTable.NewRow();
                        nR[0] = dT.Rows[i][0];
                        nR[1] = "1";
                        nR[2] = dT.Rows[i][2];
                        nR[3] = dT.Rows[i][3];
                        newTable.Rows.Add(nR);
                        break;
                    }
                }
            }
            nR = newTable.NewRow();
            nR[0] = dT.Rows[i][0];
            nR[1] = dT.Rows[i][1];
            nR[2] = dT.Rows[i][2];
            nR[3] = dT.Rows[i][3];
            nR[4] = dT.Rows[i][4];
            newTable.Rows.Add(nR);
        }
        nR = newTable.NewRow();
        nR[0] = dT.Rows[lastRow][0];
        nR[1] = dT.Rows[lastRow][1];
        nR[2] = dT.Rows[lastRow][2];
        nR[3] = dT.Rows[lastRow][3];
        nR[4] = dT.Rows[lastRow][4];
        newTable.Rows.Add(nR);
    
        dataGridView3.DataSource = null;
        dataGridView3.Rows.Clear();
        dataGridView3.DataSource = newTable;
        return;
    }
