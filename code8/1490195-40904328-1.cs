        public static void Main(string[] args)
        {
            string json = @" {
            ""children"": [
                    {
                ""url"": ""foo.pdf"", 
                        ""expanded"": false, 
                        ""label"": ""E14288-Passive-40085-2014_09_26.pdf"", 
                        ""last_modified"": ""2014-09-28T11:19:49.000Z"", 
                        ""type"": 1, 
                        ""size"": 60929
                    }
                ]
             }";
            var result = JsonConvert.DeserializeObject<ChildrenRootObject>(json);
            DataTable tbl = DataTableFromObject(result.children);
        }
        public static DataTable DataTableFromObject<T>(IList<T> list)
        {
            DataTable tbl = new DataTable();
            tbl.TableName = typeof(T).Name;
            var propertyInfos = typeof(T).GetProperties();
            List<string> columnNames = new List<string>();
            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                tbl.Columns.Add(propertyInfo.Name, propertyInfo.PropertyType);
                columnNames.Add(propertyInfo.Name);
            }
            foreach(var item in list)
            {
                DataRow row = tbl.NewRow();
                foreach (var name in columnNames)
                {
                    row[name] = item.GetType().GetProperty(name).GetValue(item, null);
                }
                tbl.Rows.Add(row);
            }
            return tbl;
        }
        public class Child
        {
            public string url { get; set; }
            public bool expanded { get; set; }
            public string label { get; set; }
            public DateTime last_modified { get; set; }
            public int type { get; set; }
            public int size { get; set; }
        }
        public class ChildrenRootObject
        {
            public List<Child> children { get; set; }
        }
