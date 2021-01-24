     public static double[] GetColumnTimeSeriesFromDataTable(DataTable table, string columnName)
        {
            var split = table.Rows.Cast<DataRow>()
                .SelectMany(r => r[columnName].ToString().Split('|'))
                .ToList();
            var replaceEmpty = split.Select((v, i) =>
                   string.IsNullOrEmpty(v) ? Previous(split, i) : v)
                .ToArray();
            return Array.ConvertAll(replaceEmpty, Double.Parse);
        }
        public static string Previous(List<string> list, int index)
        {
            var prev = list[index];
            if (index == 0 & string.IsNullOrEmpty(list[index])) 
                return Previous(list, index+1);
            else if (string.IsNullOrEmpty(prev))
                return Previous(list, index - 1);
            else
                return prev;
        }
