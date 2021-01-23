    using System;
    using System.Data;
    using System.Linq;
    using DocumentFormat.OpenXml.Packaging;
    using DocumentFormat.OpenXml.Spreadsheet;
    
    public static DataTable ReadAsDataTable(string fileName)
    {
        DataTable dataTable = new DataTable();
        using (SpreadsheetDocument spreadSheetDocument = SpreadsheetDocument.Open(fileName, false))
        {
            WorkbookPart workbookPart = spreadSheetDocument.WorkbookPart;
            IEnumerable<Sheet> sheets = spreadSheetDocument.WorkbookPart.Workbook.GetFirstChild<Sheets>().Elements<Sheet>();
            string relationshipId = sheets.First().Id.Value;
            WorksheetPart worksheetPart = (WorksheetPart)spreadSheetDocument.WorkbookPart.GetPartById(relationshipId);
            Worksheet workSheet = worksheetPart.Worksheet;
            SheetData sheetData = workSheet.GetFirstChild<SheetData>();
            IEnumerable<Row> rows = sheetData.Descendants<Row>();
    
            foreach (Cell cell in rows.ElementAt(0))
            {
                dataTable.Columns.Add(GetCellValue(spreadSheetDocument, cell));
            }
    
            foreach (Row row in rows)
            {
                DataRow dataRow = dataTable.NewRow();
                for (int i = 0; i < row.Descendants<Cell>().Count(); i++)
                {
                     Cell cell = row.Descendants<Cell>().ElementAt(i);
                     int actualCellIndex = CellReferenceToIndex(cell);
                     dataRow[actualCellIndex] = GetCellValue(spreadSheetDocument, cell);
                }
    
                dataTable.Rows.Add(dataRow);
            }
    
        }
        dataTable.Rows.RemoveAt(0);
    
        return dataTable;
    }
    
    private static string GetCellValue(SpreadsheetDocument document, Cell cell)
    {
        SharedStringTablePart stringTablePart = document.WorkbookPart.SharedStringTablePart;
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
    private static int CellReferenceToIndex(Cell cell)
    {
        int index = 0;
        string reference = cell.CellReference.ToString().ToUpper();
        foreach (char ch in reference)
        {
            if (Char.IsLetter(ch))
            {
                int value = (int)ch - (int)'A';
                index = (index == 0) ? value : ((index + 1) * 26) + value;
            }
            else
                return index;
        }
        return index;
    }
