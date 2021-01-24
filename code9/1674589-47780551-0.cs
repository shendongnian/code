    public FileContentResult WriteToExcel<T>(IEnumerable<T> data, string fileName, bool shouldGenerateSumRow = true)
        {
            using (var package = new ExcelPackage())
            {
                var ws = package.Workbook.Worksheets.Add("گزارش");
                ws.View.RightToLeft = true;
                var props = TypeDescriptor.GetProperties(typeof(T));
                var RowCount = data.Count();
                ws.Cells.LoadFromCollection(data, true, OfficeOpenXml.Table.TableStyles.Medium27);
                ws.InsertRow(1, 1);
                var excelRange = ws.Cells[1, 1, 1, props.Count];
                ws.Row(1).Height = 80;
                excelRange.Merge = true;
                excelRange.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                excelRange.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                excelRange.Style.WrapText = true;
                excelRange.Value = fileName;
                for (var i = 0; i < props.Count; i++)
                {
                    ws.Cells[2, i + 1].Value = props[i].DisplayName;
                }
                
                ws.Cells.AutoFitColumns();
                var fcr = new FileContentResult(package.GetAsByteArray(),
                    "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                {
                    FileDownloadName = $"{fileName}.xlsx"
                };
                return fcr;
            }
        }
