    using DocumentFormat.OpenXml;
    using DocumentFormat.OpenXml.Packaging;
    using DocumentFormat.OpenXml.Spreadsheet;
            private void readExcel(Stream file)
            {
                String sheetName = "Sheet2";
                String delimiter = ";";
                int startColumn = 2;// 2 convert to B 
                int endColumn = 6; // read until column 6
                int startRow = 31; // start read from row 31
    
                String columnRequest = "Request";
                DataTable dt = new DataTable();
                dt.Columns.Add(columnRequest);
                DataRow dr;
                String stringRequest = "";
                String stringNopek = "Init";
                String value = "";
                int indexRow = 0;
                using (SpreadsheetDocument myDoc = SpreadsheetDocument.Open(file, false))
                {
                    WorkbookPart wbPart = myDoc.WorkbookPart;
    
                    indexRow = startRow;
                    while (!stringNopek.Equals(""))
                    {
                        stringNopek = getCellValue(GetExcelColumnName(startColumn) + indexRow.ToString(), sheetName, wbPart).Trim();
                        stringRequest = stringNopek;
                        if (!stringNopek.Equals(""))
                        {
                            dr = dt.NewRow();
                            for (int i = startColumn + 1; i <= endColumn; i++)
                            {
                                value = getCellValue(GetExcelColumnName(i) + indexRow.ToString(), sheetName, wbPart).Trim();
                                stringRequest += delimiter + value;
                            }
                            dr[columnRequest] = stringRequest;
                            dt.Rows.Add(dr);
                        }
                        indexRow++;
                    }
                }
    
                Session["DataTableRequest"] = dt;
    
                string output = "";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    output = output + dt.Rows[i][columnRequest].ToString();
                    output += (i < dt.Rows.Count) ? Environment.NewLine : string.Empty;
                }
    
            }
    
    private string GetExcelColumnName(int columnNumber)
            {
                int dividend = columnNumber;
                string columnName = String.Empty;
                int modulo;
    
                while (dividend > 0)
                {
                    modulo = (dividend - 1) % 26;
                    columnName = Convert.ToChar(65 + modulo).ToString() + columnName;
                    dividend = (int)((dividend - modulo) / 26);
                }
    
                return columnName;
            }
    
     private int ColumnIndex(string reference)
            {
                int ci = 0;
                reference = reference.ToUpper();
                for (int ix = 0; ix < reference.Length && reference[ix] >= 'A'; ix++)
                    ci = (ci * 26) + ((int)reference[ix] - 64);
                return ci;
            }
    
    private String getCellValue(String cellReference, String sheetName, WorkbookPart wbPart)
            {
                Sheet theSheet = wbPart.Workbook.Descendants<Sheet>().
                  Where(s => s.Name == sheetName).FirstOrDefault();
                if (theSheet == null)
                {
                    throw new ArgumentException(sheetName);
                }
                WorksheetPart wsPart =
                    (WorksheetPart)(wbPart.GetPartById(theSheet.Id));
                Cell theCell = wsPart.Worksheet.Descendants<Cell>().
                  Where(c => c.CellReference == cellReference).FirstOrDefault();
    
                String value = "";
    
                if (theCell != null)
                {
                    if (theCell.CellValue != null)
                    {
                        value = theCell.CellValue.Text;
                    }
                    else
                    {
                        value = value = theCell.InnerText;
                    }
                    if (theCell.DataType != null)
                    {
                        switch (theCell.DataType.Value)
                        {
                            case CellValues.SharedString:
    
                                var stringTable =
                                    wbPart.GetPartsOfType<SharedStringTablePart>()
                                    .FirstOrDefault();
                                if (stringTable != null)
                                {
                                    value =
                                        stringTable.SharedStringTable
                                        .ElementAt(int.Parse(value)).InnerText;
                                }
                                break;
    
                            case CellValues.Boolean:
                                switch (value)
                                {
                                    case "0":
                                        value = "FALSE";
                                        break;
                                    default:
                                        value = "TRUE";
                                        break;
                                }
                                break;
                        }
                    }
                }
    
                return value;
            }
     protected void UploadControl_FileUploadComplete(object sender, FileUploadCompleteEventArgs e){
     Stream strm = e.UploadedFile.FileContent;
    readExcel(strm);
    }
