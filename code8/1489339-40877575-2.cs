    class Program
    {
        static void Main()
        {
            var dt = new DataTable();
            //populate dt...
            List<dynamic> dataTableList= dt.DataTableToList();
        }
    }
    public static class DataTableExtensions
    {
        public static List<dynamic> DataTableToList(this DataTable dt)
        {
            var list= new List<dynamic>();
            foreach (DataRow row in dt.Rows)
            {
                dynamic d = new ExpandoObject();
                list.Add(d);
                foreach (DataColumn column in dt.Columns)
                {
                    var dic = (IDictionary<string, object>)d;
                    dic[column.ColumnName] = row[column];
                }
            }
            return list;
        }
    }
