        private static bool CompareFields(Config selectedConfigCount, DataTable table)
        {
            var columns = table.Columns.Cast<DataColumn>().Select(c => c.ColumnName);
            var properties = selectedConfigCount.GetType().GetProperties();
            foreach (var property in properties)
            {
                var attributes = property.GetCustomAttributes(true);
                foreach (var attribute in attributes)
                {
                    if (attribute.GetType() == typeof(ColumnMatchAttribute))
                    {
                        //This property should be compared
                        var value = property.GetValue(selectedConfigCount);
                        if (value == null)
                            return false;
                        //Change this comparison to meet your requirements
                        if (!columns.Any(n => n == value.ToString()))
                            return false;
                    }
                }
            }
            return true;
        }
