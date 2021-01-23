     private static void AddDataRows(Excel.Worksheet sheet, DataTable table, object[,] tempArray)
        {
           
                var range = sheet.Range(sheet.Cells[2, 1], sheet.Cells[(table.Rows.Count), (table.Columns.Count)]);
                range.Value = tempArray;
                sheet.Name = table.TableName;
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    for (int j = 0; j < table.Columns.Count; j++)
                    {
                        if (table.Columns[j].DataType == typeof(decimal))
                        {
                            sheet.Cells[i+2, j+1].Value = ConvertNumberFormat.ConvertToDecimal(Convert.ToDecimal( sheet.Cells[i+2 , j+1 ].Value));
                        }
                    }
                }
             
        }
