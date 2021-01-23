    public class DataInSheet
        {
            public string firstRow { get; set; }
            internal static IEnumerable<object> GetDataOfSheet()
            {
                List<DataInSheet> dataForSheet = new List<DataInSheet>
                {
                    new DataInSheet
                    {
                        firstRow  = "Sanjay"
                    },
                    new DataInSheet
                    {
                        firstRow  = "Sanjay"
                    },
                    new DataInSheet
                    {
                        firstRow  = "Sanjay"
                    },
                    new DataInSheet
                    {
                        firstRow  = "Sanjay"
                    },
                    new DataInSheet
                    {
                        firstRow  = "Sanjay"
                    },
                    new DataInSheet
                    {
                        firstRow  = "Sanjay"
                    },
                };
                return dataForSheet;
            }
        }
        public static void CreateExcelWithDynamicHeader(string fileName, List<string> headerFields, string sheetName, string dropDownItems)
        {
            using (SpreadsheetDocument document = SpreadsheetDocument.Create(fileName, SpreadsheetDocumentType.Workbook))
            {
                WorkbookPart workbookPart = document.AddWorkbookPart();
                workbookPart.Workbook = new Workbook();
                WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                worksheetPart.Worksheet = new Worksheet(new SheetData());
                WorksheetPart worksheetPart2 = workbookPart.AddNewPart<WorksheetPart>();
                worksheetPart2.Worksheet = new Worksheet(new SheetData());
                Sheets sheets = document.WorkbookPart.Workbook.AppendChild<Sheets>(new Sheets());
                //sheets.Append(sheets);
                Worksheet worksheet1 = new Worksheet()
                { MCAttributes = new MarkupCompatibilityAttributes() { Ignorable = "x14ac" } };
                worksheet1.AddNamespaceDeclaration
                ("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
                worksheet1.AddNamespaceDeclaration
                ("mc", "http://schemas.openxmlformats.org/markup-compatibility/2006");
                worksheet1.AddNamespaceDeclaration
                ("x14ac", "http://schemas.microsoft.com/office/spreadsheetml/2009/9/ac");
                Worksheet worksheet2 = new Worksheet()
                { MCAttributes = new MarkupCompatibilityAttributes() { Ignorable = "x14ac" } };
                worksheet2.AddNamespaceDeclaration
                ("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
                worksheet2.AddNamespaceDeclaration
                ("mc", "http://schemas.openxmlformats.org/markup-compatibility/2006");
                worksheet2.AddNamespaceDeclaration
                ("x14ac", "http://schemas.microsoft.com/office/spreadsheetml/2009/9/ac");
                Sheet sheet = new Sheet() { Id = document.WorkbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = sheetName };
                Sheet sheet1 = new Sheet() { Id = document.WorkbookPart.GetIdOfPart(worksheetPart2), SheetId = 2, Name = dropDownItems };
                sheets.Append(sheet);
                sheets.Append(sheet1);
                //document.WorkbookPart.Workbook.Save();
                SheetData sheetData = new SheetData();
                SheetData sheetData1 = new SheetData();
                double width = 6;
                // Constructing header
                Row headerRow = new Row();
                for (int i = 0; i < headerFields.Count; i++)
                {
                    if (width < headerFields[i].Length)
                    {
                        width = headerFields[i].Length;
                    }
                    Columns columns = new Columns();
                    columns.Append(new Column() { Min = 1, Max = (UInt32)headerFields.Count, Width = width, CustomWidth = true });
                    worksheetPart.Worksheet.Append(columns);
                    Cell cell = new Cell();
                    cell.DataType = CellValues.String;
                    cell.CellValue = new CellValue(headerFields[i]);
                    headerRow.AppendChild(cell);
                }
                sheetData.AppendChild(headerRow);
                worksheet1.Append(sheetData);
                int Counter = 1;
                foreach (var value in DataInSheet.GetDataOfSheet())
                {
                    Row contentRow = CreateRowValues(Counter, value);
                    Counter++;
                    sheetData1.AppendChild(contentRow);
                }
                worksheet2.Append(sheetData1);
                DataValidation dataValidation = new DataValidation
                {
                    Type = DataValidationValues.List,
                    AllowBlank = true,
                    SequenceOfReferences = new ListValue<StringValue>() { InnerText = "B1" },
                    //Formula1 = new Formula1("'Import Face'!$A$1:$A$6")
                    Formula1 = new Formula1("'DropDownDataContainingSheet'!$A:$A")
                };
                DataValidations dataValidations = worksheet1.GetFirstChild<DataValidations>();
                if (dataValidations != null)
                {
                    dataValidations.Count = dataValidations.Count + 1;
                    dataValidations.Append(dataValidation);
                }
                else
                {
                    DataValidations newdataValidations = new DataValidations();
                    newdataValidations.Append(dataValidation);
                    newdataValidations.Count = 1;
                    worksheet1.Append(newdataValidations);
                }
                worksheetPart.Worksheet = worksheet1; ;
                worksheetPart2.Worksheet = worksheet2;
                workbookPart.Workbook.Save();
                document.Close();
            }
        }
        static string[] headerColumns = new string[] { "A", "B", "C", "D" };
        private static Row CreateRowValues(int index, object value)
        {
            Row row = new Row();
            row.RowIndex = (UInt32)index;
            int i = 0;
            foreach (var property in value.GetType().GetProperties())
            {
                Cell cell = new Cell();
                cell.CellReference = headerColumns[i].ToString() + index;
                if (property.PropertyType.ToString()
                .Equals("System.string", StringComparison.InvariantCultureIgnoreCase))
                {
                    var result = property.GetValue(value, null);
                    if (result == null)
                    {
                        result = "";
                    }
                    cell.DataType = CellValues.String;
                    InlineString inlineString = new InlineString();
                    Text text = new Text();
                    text.Text = result.ToString();
                    inlineString.AppendChild(text);
                    cell.AppendChild(inlineString);
                }
                if (property.PropertyType.ToString()
                .Equals("System.int32", StringComparison.InvariantCultureIgnoreCase))
                {
                    var result = property.GetValue(value, null);
                    if (result == null)
                    {
                        result = 0;
                    }
                    CellValue cellValue = new CellValue();
                    cellValue.Text = result.ToString();
                    cell.AppendChild(cellValue);
                }
                if (property.PropertyType.ToString()
                .Equals("System.boolean", StringComparison.InvariantCultureIgnoreCase))
                {
                    var result = property.GetValue(value, null);
                    if (result == null)
                    {
                        result = "False";
                    }
                    cell.DataType = CellValues.InlineString;
                    InlineString inlineString = new InlineString();
                    Text text = new Text();
                    text.Text = result.ToString();
                    inlineString.AppendChild(text);
                    cell.AppendChild(inlineString);
                }
                row.AppendChild(cell);
                i = i + 1;
            }
            return row;
        }
