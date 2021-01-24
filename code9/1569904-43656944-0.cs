    public object DataTableToJSON(DataTable table)
        {
            var list = new List<Dictionary<string, object>>();
            
            foreach (DataRow row in table.Rows)
            {
                var dict = new Dictionary<string, object>();
                var counter = 1;
                foreach (DataColumn col in table.Columns)
                {
                    dict.Add(counter.ToString(),row[col]);
                    counter++;
                }
                list.Add(dict);
            }
            JavaScriptSerializer serializer = new JavaScriptSerializer();
    
            return serializer.Serialize(list);
        }
