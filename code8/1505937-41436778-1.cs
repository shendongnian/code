        using CarlosAg.ExcelXmlWriter;
        
        class TestApp {
            static void Main(string[] args) {
                Workbook book = new Workbook();
                Worksheet sheet = book.Worksheets.Add("Sample");
                WorksheetRow row =  sheet.Table.Rows.Add();
                row.Cells.Add("Hello World");
                book.Save(@"c:\test.xls");
            }
        }
