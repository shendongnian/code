                if (_output != null)
                {
                    a = new Excel.Application();
                    if(a==null)
                    {
                        Console.WriteLine("Excel is not properly installed.");
                        Environment.Exit(1);
                    }
                    else
                    {
                        b = a.Workbooks.Add(misValue);
                        s1 = (Excel.Worksheet)b.Worksheets.get_Item(1);
                        s1.Name = "Audit";
                        s1.Cells[1, 1] = "Computer Name";
                        r = s1.Range["A1" , "A1"];
                        r.EntireColumn.ColumnWidth = TextRenderer.MeasureText("Computer Name", new Font("Calibri", 11, FontStyle.Regular)).Width / 7;
                        s1.Cells[1, 2] = "Manufacturer";
                        r = s1.Range["B1" , "B1"];
                        r.EntireColumn.ColumnWidth = TextRenderer.MeasureText("Manufacturer", new Font("Calibri", 11, FontStyle.Regular)).Width / 7;
                        s1.Cells[1, 3] = "Motherboard Model (HP)";
                        r = s1.Range["C1" , "C1"];
                        r.EntireColumn.ColumnWidth = TextRenderer.MeasureText("Motherboard Model (HP)", new Font("Calibri", 11, FontStyle.Regular)).Width / 7;
                        s1.Cells[1, 4] = "Motherboard Model (Other)";
                        r = s1.Range["D1" , "D1"];
                        r.EntireColumn.ColumnWidth = TextRenderer.MeasureText("Motherboard Model (Other)", new Font("Calibri", 11, FontStyle.Regular)).Width / 7;
                        s1.Cells[1, 5] = "Product Number (HP)";
                        r = s1.Range["E1" , "E1"];
                        r.EntireColumn.ColumnWidth = TextRenderer.MeasureText("Product Number (HP)", new Font("Calibri", 11, FontStyle.Regular)).Width / 7;
                        s1.Cells[1, 6] = "Serial Number (HP)";
                        r = s1.Range["F1" , "F1"];
                        r.EntireColumn.ColumnWidth = TextRenderer.MeasureText("Serial Number (HP)", new Font("Calibri", 11, FontStyle.Regular)).Width / 7;
                        s1.Cells[1, 7] = "Serial Number (Other)";
                        r = s1.Range["G1" , "G1"];
                        r.EntireColumn.ColumnWidth = TextRenderer.MeasureText("Serial Number (Other)", new Font("Calibri", 11, FontStyle.Regular)).Width / 7;
                        s1.Cells[1, 8] = "CPU";
                        r = s1.Range["H1" , "H1"];
                        r.EntireColumn.ColumnWidth = TextRenderer.MeasureText("CPU", new Font("Calibri", 11, FontStyle.Regular)).Width / 7;
                        s1.Cells[1, 9] = "Cores";
                        r = s1.Range["I1" , "I1"];
                        r.EntireColumn.ColumnWidth = TextRenderer.MeasureText("Cores", new Font("Calibri", 11, FontStyle.Regular)).Width / 7;
                        s1.Cells[1, 10] = "Threads";
                        r = s1.Range["J1" , "J1"];
                        r.EntireColumn.ColumnWidth = TextRenderer.MeasureText("Threads", new Font("Calibri", 11, FontStyle.Regular)).Width / 7;
                        s1.Cells[1, 11] = "Memory";
                        r = s1.Range["K1" , "K1"];
                        r.EntireColumn.ColumnWidth = TextRenderer.MeasureText("Memory", new Font("Calibri", 11, FontStyle.Regular)).Width / 7;
                        s1.Cells[1, 12] = "Graphics Card";
                        r = s1.Range["L1" , "L1"];
                        r.EntireColumn.ColumnWidth = TextRenderer.MeasureText("Graphics Card", new Font("Calibri", 11, FontStyle.Regular)).Width / 7;
                        s1.Cells[1, 13] = "Disk Model(s)";
                        r = s1.Range["M1" , "M1"];
                        r.EntireColumn.ColumnWidth = TextRenderer.MeasureText("Disk Model(s)", new Font("Calibri", 11, FontStyle.Regular)).Width / 7;
                        s1.Cells[1, 14] = "Disk Size(s)";
                        r = s1.Range["N1" , "N1"];
                        r.EntireColumn.ColumnWidth = TextRenderer.MeasureText("Disk Size(s)", new Font("Calibri", 11, FontStyle.Regular)).Width / 7;
                        s1.Cells[1, 15] = "Operating System";
                        r = s1.Range["O1" , "O1"];
                        r.EntireColumn.ColumnWidth = TextRenderer.MeasureText("Operating System", new Font("Calibri", 11, FontStyle.Regular)).Width / 7;
                        s1.Cells[1, 16] = "Architecture";
                        r = s1.Range["P1" , "P1"];
                        r.EntireColumn.ColumnWidth = TextRenderer.MeasureText("Architecture", new Font("Calibri", 11, FontStyle.Regular)).Width / 7;
                        s2 = b.Sheets.Add(Type.Missing, Type.Missing, 1, Type.Missing);
                        s2.Name = "uncontactable";
                        int totalSheets = a.ActiveWorkbook.Sheets.Count;
                        s1.Move(a.Worksheets[1]);
                        for(int c = 0; c < queue.Count; c++)
                        {
                            row = c + 2;
                            specs = new List<string>();
                            specs.AddRange(getSpecs(queue[c], _user, _pass));
                            foreach(string n in specs)
                            {
                                if (n.StartsWith("Computer Name: ") == true)
                                {
                                    s1.Cells[row, 1] = n.Substring(n.IndexOf(':') + 2);
                                    column = 1;
                                }
                                else if (n.StartsWith("Manufacturer: ") == true)
                                {
                                    s1.Cells[row, 2] = n.Substring(n.IndexOf(':') + 2);
                                    column = 2;
                                }
                                else if (n.StartsWith("Motherboard Model(HP): ") == true)
                                {
                                    s1.Cells[row, 3] = n.Substring(n.IndexOf(':') + 2);
                                    column = 3;
                                }
                                else if (n.StartsWith("Motherboard Model(Other): ") == true)
                                {
                                    s1.Cells[row, 4] = n.Substring(n.IndexOf(':') + 2);
                                    column = 4;
                                }
                                else if (n.StartsWith("Product Number(HP): ") == true)
                                {
                                    s1.Cells[row, 5] = n.Substring(n.IndexOf(':') + 2);
                                    column = 5;
                                }
                                else if (n.StartsWith("Serial Number(HP): ") == true)
                                {
                                    s1.Cells[row, 6] = n.Substring(n.IndexOf(':') + 2);
                                    column = 6;
                                }
                                else if (n.StartsWith("Serial Number(Other): ") == true)
                                {
                                    s1.Cells[row, 7] = n.Substring(n.IndexOf(':') + 2);
                                    column = 7;
                                }
                                else if (n.StartsWith("CPU: ") == true)
                                {
                                    s1.Cells[row, 8] = n.Substring(n.IndexOf(':') + 2);
                                    column = 8;
                                }
                                else if (n.StartsWith("Cores: ") == true)
                                {
                                    s1.Cells[row, 9] = n.Substring(n.IndexOf(':') + 2);
                                    column = 9;
                                }
                                else if (n.StartsWith("Threads: ") == true)
                                {
                                    s1.Cells[row, 10] = n.Substring(n.IndexOf(':') + 2);
                                    column = 10;
                                }
                                else if (n.StartsWith("Memory: ") == true)
                                {
                                    s1.Cells[row, 11] = n.Substring(n.IndexOf(':') + 2);
                                    column = 11;
                                }
                                else if (n.StartsWith("Graphics Card: ") == true)
                                {
                                    ch = Convert.ToString(s1.Cells[row,12].Value);
                                    if (ch == null)
                                    {
                                        s1.Cells[row, 12] = n.Substring(n.IndexOf(':') + 2);
                                    }
                                    else
                                    {
                                        s1.Cells[row, 12] = s1.Cells[row, 12].Value + "\n" + n.Substring(n.IndexOf(':') + 2);
                                    }
                                    column = 12;
                                }
                                else if (n.StartsWith("Disk Model: ") == true)
                                {
                                    ch = Convert.ToString(s1.Cells[row, 13].Value);
                                    if (ch == null)
                                    {
                                        s1.Cells[row, 13] = n.Substring(n.IndexOf(':') + 2);
                                    }
                                    else
                                    {
                                        s1.Cells[row, 13] = s1.Cells[row, 13].Value + "\n" + n.Substring(n.IndexOf(':') + 2);
                                    }
                                    column = 13;
                                }
                                else if (n.StartsWith("Disk Size: ") == true)
                                {
                                    ch = Convert.ToString(s1.Cells[row, 14].Value);
                                    if (ch == null)
                                    {
                                        s1.Cells[row, 14] = n.Substring(n.IndexOf(':') + 2);
                                    }
                                    else
                                    {
                                        s1.Cells[row, 14] = s1.Cells[row, 14].Value + "\n" + n.Substring(n.IndexOf(':') + 2);
                                    }
                                    column = 14;
                                }
                                else if (n.StartsWith("Operating System: ") == true)
                                {
                                    s1.Cells[row, 15] = n.Substring(n.IndexOf(':') + 2);
                                    column = 15;
                                }
                                else if (n.StartsWith("Architecture: ") == true)
                                {
                                    s1.Cells[row, 16] = n.Substring(n.IndexOf(':') + 2);
                                    column = 16;
                                }
                                //If text in the cell has dimensions greater than the cell's row and/or column, resize row and/or column to be the same
                                r = s1.Range[getColumnLetter(column)+row.ToString(),getColumnLetter(column)+row.ToString()];
                                if (TextRenderer.MeasureText(s1.Cells[row, column].Value.ToString(), f).Width / 7 > r.EntireColumn.ColumnWidth)
                                {
                                    r.EntireColumn.ColumnWidth = TextRenderer.MeasureText(n.Substring(n.IndexOf(':') + 2), f).Width / 7;
                                }
                                for(int d = 1; d <= 16; d++)
                                {
                                    ch = Convert.ToString(s1.Cells[row, d].Value);
                                    if(ch != null)
                                    {
                                        if (((TextRenderer.MeasureText(s1.Cells[row, d].Value.ToString(), f).Height) / 18) * 15 > rh)
                                        {
                                            rh = ((TextRenderer.MeasureText(s1.Cells[row, d].Value.ToString(), f).Height) / 18) * 15;
                                        }
                                    }
                                }
                                r.EntireRow.RowHeight = rh;
                            }
                        }
                        a.DisplayAlerts = false;
                        b.SaveAs(_output, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                        b.Close(true, misValue, misValue);
                        a.Quit();
                        Marshal.ReleaseComObject(s1);
                        Marshal.ReleaseComObject(s2);
                        Marshal.ReleaseComObject(b);
                        Marshal.ReleaseComObject(a);
                        Console.Read();
                    }
                }
