    public class Program
    {
        static void Main()
        {
            //make dummy data
            List<DataTable> dts = new List<DataTable>();
            Random rnd = new Random();
            for (int i = 0; i < 20; i++)
            {
                var dt = new DataTable();
                dt.Columns.Add("foo", typeof(int));
                dt.Columns.Add("bar", typeof(int));
                dt.Columns.Add("baz", typeof(int));
                dt.Columns.Add("Value", typeof(int));
                for (int j = 0; j < 1000; j++)
                {
                    dt.Rows.Add(rnd.Next(1, 5), rnd.Next(1, 5), rnd.Next(1, 5), rnd.Next(1, 2000));
                }
                dts.Add(dt);
            }
            //dummy data complete
            // the grouping step
            var intermediateResult = dts.SelectMany(x => x.Rows.Cast<DataRow>()).GroupBy(x => x, new NotValueColumnComparer()).Select(x => new { grp = x.Key, sum = x.Sum(y => y.Field<int>("Value")) });
            // transform back into a data tabe
            var result = new DataTable();
            foreach (var col in dts.First().Columns.Cast<DataColumn>())
            {
                result.Columns.Add(col.ColumnName);
            }
            foreach (var item in intermediateResult)
            {
                var row = result.NewRow();
                foreach (var grpField in item.grp.Table.Columns.Cast<DataColumn>().Where(x => x.ColumnName != "Value"))
                {
                    row[grpField.ColumnName] = item.grp[grpField.ColumnName];
                }
                row["Value"] = item.sum;
                result.Rows.Add(row);
            }
            //transform end
        }
        //the class that does the trick
        public class NotValueColumnComparer : IEqualityComparer<DataRow>
        {
            //compare all columns but the Value column
            public bool Equals(DataRow x, DataRow y)
            {
                foreach (var col in x.Table.Columns.Cast<DataColumn>())
                {
                    if (col.ColumnName != "Value")
                        if (x[col.ColumnName] != y[col.ColumnName])
                            return false;
                }
                return true;
            }
            //as a simple hash code ... just xor the values hash codes
            public int GetHashCode(DataRow obj)
            {
                int res = 0;
                foreach (var col in obj.Table.Columns.Cast<DataColumn>())
                {
                    if (col.ColumnName != "Value")
                        res ^= obj[col].GetHashCode();
                }
                return res;
            }
        }
    }
