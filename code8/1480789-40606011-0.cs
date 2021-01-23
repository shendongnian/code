    public static IEnumerable<string> ToCsvList(this DataTable table)
        {
            List<string> returnList = new List<string>();
            string colmn = string.Join(",", table.Columns.OfType<DataColumn>().Select(c => c.ColumnName));
            returnList.Add(colmn);
            foreach (DataRow row in table.Rows)
            {
                returnList.Add(string.Join(",", row.ItemArray));
            }
            return returnList;
        }
