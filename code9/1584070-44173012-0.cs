    public static void ExportToCSV(DataTable contentToexport)
            {
                var csvData = new StringBuilder();
                foreach (DataColumn column in contentToexport.Columns)
                {
                    if (csvData.Length > 0) csvData.Append(",");
                    csvData.Append(column.ColumnName);
                }
                csvData.Append(Environment.NewLine);
                foreach (DataRow row in contentToexport.Rows)
                {
                    var newLine = true;
                    foreach (DataColumn column in contentToexport.Columns)
                    {
                        if (!newLine) csvData.Append(",");
                        newLine = false;
                        var cellValue = row[column].ToString();
                        var cellValueHasQuotes = cellValue.Contains("\"");
                        if (cellValueHasQuotes)
                        {
                            csvData.Append("\"");
                            cellValue = cellValue.Replace("\"", "\"\"");
                        }
                        csvData.Append(cellValue);
                        if (cellValueHasQuotes)
                        {
                            csvData.Append("\"");
                        }
                    }
                    csvData.Append(Environment.NewLine);
                }
                string contentToExport = csvData.ToString();
                string attachment = "attachment; filename=export.csv";
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ClearHeaders();
                HttpContext.Current.Response.ClearContent();
                HttpContext.Current.Response.AddHeader("content-disposition", attachment);
                HttpContext.Current.Response.ContentType = "application/csv";
                HttpContext.Current.Response.AddHeader("Pragma", "public");
                HttpContext.Current.Response.Write(contentToExport);
                System.Web.HttpContext.Current.ApplicationInstance.CompleteRequest();
            }
