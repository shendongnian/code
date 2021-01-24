        public static string DataTableToJSON(DataTable table)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            Dictionary<string, object> row;
            var innerList = new string[] { "Name", "Value", "Unit", "MinValue", "MaxValue" };
            var innerRow = new Dictionary<string, object>();
            foreach (DataRow dr in table.Rows)
            {
                row = new Dictionary<string, object>();
                foreach (DataColumn col in table.Columns)
                {
                    if (innerList.Contains(col.ColumnName))
                    {
                        innerRow.Add(col.ColumnName, dr[col]);
                    }
                    else
                    {
                        row.Add(col.ColumnName, dr[col]);
                    }
                }
                row.Add("VitalThreshold", innerRow);
                rows.Add(row);
            }
            serializer.MaxJsonLength = int.MaxValue;
            return serializer.Serialize(rows);
        }
