            workbook.Worksheets.Clear();
            workbook.Worksheets.Add(worksheet); 
            n++;
            {
                    
                    worksheet.Cells.ColumnWidth[0, 1] = 10000;
                    string myFileName = String.Format("{0}__{1}", DateTime.Now.ToString("yyyyMMdd"), ".csv");
                    string myFullPath = Path.Combine("C:\\", myFileName);
                    workbook.Save(myFileName);
                    worksheet.Cells[n, 0] = new Cell(DateTime.Now.ToString( @"HH:mm:ss"));
                    worksheet.Cells[n, 1] = new Cell(DataFromCOM);
                    worksheet.Cells[n, 2] = new Cell(val);
                    
                }
