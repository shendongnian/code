    var stream = File.Open(@"C:\temp\Book1.xlsx", FileMode.Open, FileAccess.Read);
                        
    var excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
    
    var result = excelReader.AsDataSet();
    
    var tables = result.Tables
                       .Cast<DataTable>()
                       .Select(t => new {
                                         TableName = t.TableName,
                                         Columns = t.Columns
                                                    .Cast<DataColumn>()
                                                    .Select(x => x.ColumnName)
                                                    .ToList()
                              });
