        DataTable src1 = gv1.DataSource as DataTable;
        DataTable src2 = gv2.DataSource as DataTable;
        int index1 = 0;
        foreach (DataRow row1 in src1.Rows)
        {
            foreach (DataRow row2 in src2.Rows)
            {
                int index2 = 0;
                bool duplicateRow = true;
                for (int cellIndex = 0; cellIndex < row1.ItemArray.Count(); cellIndex++)
                {
                    if (!row1.ItemArray[cellIndex].Equals(row2.ItemArray[cellIndex].ToString()))
                    {
                        duplicateRow = true;
                        break;
                    }
                }
                if (duplicateRow)
                {
                    gv1.Rows[index1].DefaultCellStyle.ForeColor = Color.Red;
                }
                index2++;
            }
            index1++;
        }
    }
