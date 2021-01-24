    using DocumentFormat.OpenXml.Packaging;
    using DocumentFormat.OpenXml.Spreadsheet;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;
    
    namespace OpenXMLDemo
    {
        class Program
        {
            static void Main(string[] args)
            {
                Program p = new Program();
    
                System.Data.DataTable data = p.ExtractExcel(@"C:\TempData\");
            }
    
            public System.Data.DataTable ExtractExcel(string fullPath)
            {
                var excelFileToImport = Directory.GetFiles(fullPath, "Data_Import.xlsx", SearchOption.AllDirectories);
    
                //Create a new DataTable.
                System.Data.DataTable dt = new System.Data.DataTable();
    
                //Open the Excel file in Read Mode using OpenXML
                using (SpreadsheetDocument doc = SpreadsheetDocument.Open(excelFileToImport[0], false))
                {
                    WorksheetPart titlesWorksheetPart = GetWorksheetPart(doc.WorkbookPart, "Titles");
    
                    Worksheet titlesWorksheet = titlesWorksheetPart.Worksheet;
    
                    //Fetch all the rows present in the worksheet
                    IEnumerable<Row> rows = titlesWorksheet.GetFirstChild<SheetData>().Descendants<Row>();
    
                    foreach (Cell cell in rows.ElementAt(1))
                    {
                        dt.Columns.Add(GetCellValue(doc, cell)); // this will include 2nd row a header row
                    }
    
                    //Loop through the Worksheet rows
                    foreach (Row row in rows)
                    {
                        if (row.RowIndex.Value > 2) //this will exclude first two rows
                        {
                            System.Data.DataRow tempRow = dt.NewRow();
                            int columnIndex = 0;
                            foreach (Cell cell in row.Descendants<Cell>())
                            {
                                // Gets the column index of the cell with data
                                int cellColumnIndex = (int)GetColumnIndexFromName(GetColumnName(cell.CellReference));
                                cellColumnIndex--; //zero based index
                                if (columnIndex < cellColumnIndex)
                                {
                                    do
                                    {
                                        tempRow[columnIndex] = ""; //Insert blank data here;
                                        columnIndex++;
                                    }
                                    while (columnIndex < cellColumnIndex);
                                }
                                tempRow[columnIndex] = GetCellValue(doc, cell);
    
                                columnIndex++;
                            }
                            dt.Rows.Add(tempRow);
                        }
                    }
                }
                return dt;
            }
            public static string GetCellValue(SpreadsheetDocument document, Cell cell)
            {
                SharedStringTablePart stringTablePart = document.WorkbookPart.SharedStringTablePart;
                if (cell.CellValue == null)
                {
                    return "";
                }
                string value = cell.CellValue.InnerXml;
                if (cell.DataType != null && cell.DataType.Value == CellValues.SharedString)
                {
                    return stringTablePart.SharedStringTable.ChildElements[Int32.Parse(value)].InnerText;
                }
                else
                {
                    return value;
                }
            }
            /// <summary>
            /// Given a cell name, parses the specified cell to get the column name.
            /// </summary>
            /// <param name="cellReference">Address of the cell (ie. B2)</param>
            /// <returns>Column Name (ie. B)</returns>
            public static string GetColumnName(string cellReference)
            {
                // Create a regular expression to match the column name portion of the cell name.
                Regex regex = new Regex("[A-Za-z]+");
                Match match = regex.Match(cellReference);
                return match.Value;
            }
            /// <summary>
            /// Given just the column name (no row index), it will return the zero based column index.
            /// Note: This method will only handle columns with a length of up to two (ie. A to Z and AA to ZZ). 
            /// A length of three can be implemented when needed.
            /// </summary>
            /// <param name="columnName">Column Name (ie. A or AB)</param>
            /// <returns>Zero based index if the conversion was successful; otherwise null</returns>
            public static int? GetColumnIndexFromName(string columnName)
            {
                //return columnIndex;
                string name = columnName;
                int number = 0;
                int pow = 1;
                for (int i = name.Length - 1; i >= 0; i--)
                {
                    number += (name[i] - 'A' + 1) * pow;
                    pow *= 26;
                }
                return number;
            }
            public WorksheetPart GetWorksheetPart(WorkbookPart workbookPart, string sheetName)
            {
                string relId = workbookPart.Workbook.Descendants<Sheet>().First(s => sheetName.Equals(s.Name)).Id;
                return (WorksheetPart)workbookPart.GetPartById(relId);
            }
        }
    }
