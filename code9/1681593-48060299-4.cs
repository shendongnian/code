        static List<Second> ReadFromExcel(string filePath) {
            List<Second> result = new List<Second>();
            PropertyInfo[] props = typeof(Second).GetProperties();
            //Allow access propertyInfo by name
            Dictionary<string, PropertyInfo> properties = new Dictionary<string, PropertyInfo>();
            foreach (var pi in props) {
                properties.Add(pi.Name, pi);
            }
            using (var xls = new ExcelPackage(new FileInfo(filePath))) {
                
                ExcelWorksheet ws = xls.Workbook.Worksheets[0];
                //Let's assume you have property names has row heading in Excel
                List<string> names = new List<string>(3);
                for (int i = 1; i <= 4; i++) {
                    names.Add(ws.Cells[1, i].Value.ToString());
                }
                //Fill the list from Excel
                for (int row = 3; row <= ws.Dimension.End.Row; row++) {
                    Second second = new Second();
                    for (int col = 1; col <= 4; col++) {
                        object value = ws.Cells[row, col].Value;
                        if (value != null)
                            properties[names[col]].SetValue(second, value);
                    }
                    result.Add(second);
                }
            }
            return result;
        }
