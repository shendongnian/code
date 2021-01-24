        public void WriteFile<THeader, TEntity>(THeader header, params TEntity[] contents)
        {
            if (!File.Exists(FileInformation.FullName))
                File.Create(FileInformation.FullName).Close();
            using (var excel = new ExcelPackage())
            {
                ExcelWorksheet worksheet = excel.Workbook.Worksheets.Add(FileInformation.Name);
                CreateExcelWorksheetHeader(worksheet, header);
                var row = 2;
                Dictionary<int, object> mapping = BuildTableMap(worksheet, 1);
                foreach (TEntity content in contents)
                {
                    MapEntityToRow(worksheet, mapping, row, content);
                    row++;
                }
                excel.SaveAs(FileInformation);
            }
        }
        private static void CreateExcelWorksheetHeader<THeader>(ExcelWorksheet worksheet, THeader entity)
        {
            var index = 1;
            PropertyInfo[] properties = typeof(THeader).GetProperties();
            foreach (PropertyInfo property in properties)
            {
                worksheet.Cells[1, index].Value = property.GetValue(entity, null);
                index++;
            }
        }
        private static void MapEntityToRow<TEntity>(ExcelWorksheet worksheet, Dictionary<int, object> table, int row, TEntity entity)
        {
            IDictionary<string, string> properties = ObjectMapper.GetPropertyNameAndAttribute<TEntity>();
            foreach (KeyValuePair<int, object> column in table)
            {
                var matchColumnToProperty = properties.SingleOrDefault(property => string.Compare(property.Key, (string)column.Value, true) == 0).Key;
                var matchColumnToAttribute = properties.SingleOrDefault(property => string.Compare(property.Value, (string)column.Value, true) == 0).Value;
                if (matchColumnToProperty != null)
                    worksheet.Cells[row, column.Key].Value =
                        typeof(TEntity).GetProperty(matchColumnToProperty).GetValue(entity, null);
                if (matchColumnToAttribute != null)
                    worksheet.Cells[row, column.Key].Value =
                        typeof(TEntity).GetProperty(properties.SingleOrDefault(property => string.Compare(property.Value, matchColumnToAttribute, true) == 0).Key)
                        .GetValue(entity, null);
            }
        }
