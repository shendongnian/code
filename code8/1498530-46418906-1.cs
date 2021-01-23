    //Read the first Sheet from Excel file.
                IXLWorksheet workSheet = workBook.Worksheet(1);
                //Create a new DataTable.
                DataTable dt = new DataTable();
                //Loop through the Worksheet rows.
                bool firstRow = true;
                foreach (IXLRow row in workSheet.Rows())
                {
                    //Use the first row to add columns to DataTable.
                    if (firstRow)
                    {
                        foreach (IXLCell cell in row.Cells())
                        {
                            dt.Columns.Add(cell.Value.ToString());
                        }
                        firstRow = false;
                    }
                    else
                    {
                        //Add rows to DataTable.
                        dt.Rows.Add();
                        int i = 0;
                        //for (IXLCell cell in row.Cells())
                        for (int j=1;j<= dt.Columns.Count;j++)
                        {
                            if (string.IsNullOrEmpty(row.Cell(j).Value.ToString()))
                                dt.Rows[dt.Rows.Count - 1][i] = "";
                            else
                                dt.Rows[dt.Rows.Count - 1][i] = row.Cell(j).Value.ToString();
                            i++;
                        }
                    }
                }
