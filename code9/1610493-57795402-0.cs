        private DataTable ConvertExcelToDataTable(string path)
        {
                using (Stream inputStream = File.OpenRead(path))
                {
                    using (ExcelEngine excelEngine = new ExcelEngine())
                    {
                        IApplication application = excelEngine.Excel;
                        IWorkbook workbook = application.Workbooks.Open(inputStream);
                        IWorksheet worksheet = workbook.Worksheets[0];
                        DataTable dataTable = worksheet.ExportDataTable(worksheet.UsedRange, ExcelExportDataTableOptions.ColumnNames);
                        return dataTable;
                    }
                }
        }
