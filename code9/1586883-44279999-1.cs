                if(hexGridView1.CurrentCell.EditedFormattedValue.ToString().Length == 2)
                {
                    int iColumn = hexGridView1.CurrentCell.ColumnIndex;
                    int iRow = hexGridView1.CurrentCell.RowIndex;
                    if (iColumn == hexGridView1.ColumnCount - 1)
                    {
                        if (hexGridView1.RowCount > (iRow + 1))
                        {
                            hexGridView1.CurrentCell = hexGridView1[0, iRow + 1];
                        }
                        else
                        {
                            //focus next control
                        }
                    }
                    else
                        hexGridView1.CurrentCell = hexGridView1[iColumn + 1, iRow];
                }
