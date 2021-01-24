          for (int i = 0; i < data.Rows.Count; i++)
                {
                    if (Emp == Convert.ToInt32(data.Rows[i][0]))
                    {
                        IRow row = sheet1.CreateRow(row_num);
                        num++; row_num++;
                        for (int j = 0; j < data.Columns.Count; j++)
                        {
                            ICell cell = row.CreateCell(j);
                            sheet1.AutoSizeColumn(j); //control cell width
                            String columnName = data.Columns[j].ToString();
                            cell.SetCellValue(data.Rows[i][columnName].ToString());
                        }
                    }
                }
