            for (int j = 0; j < DGV.Columns.Count; j++)
            {
                worksheet.Cells[cellRowIndex, cellColumnIndex] = DGV.Columns[j].HeaderText;
                cellColumnIndex++;
            }
            cellRowIndex++;
            //Loop through each row and read value from each column. 
            for (int i = 0; i < DGV.Rows.Count; i++)
            {
                for (int j = 0; j < DGV.Columns.Count; j++)
                {
                    worksheet.Cells[cellRowIndex, cellColumnIndex] = DGV.Rows[i].Cells[j].Value.ToString();
                    cellColumnIndex++;
                }
                cellColumnIndex = 1;
                cellRowIndex++;
            }
