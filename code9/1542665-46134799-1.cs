    public static class StringItemExtensions
    {
        public static DataTable ToDataTable(this List<StringItem> list)
        {
            var dt = new DataTable();
            dt.Columns.Add("Name").ReadOnly = true;
            dt.PrimaryKey = new DataColumn[] { dt.Columns["Name"] };
            dt.Columns.Add("Comment");
            StringItem.LanguageNames.ToList().ForEach(x => dt.Columns.Add(x));
            list.ForEach(item =>
            {
                var values = new List<object>();
                values.Add(item.Name);
                values.Add(item.Comment);
                values.AddRange(item.Languages.Values.Cast<string>());
                dt.Rows.Add(values.ToArray());
            });
            return dt;
        }
        public static List<StringItem> ToStringItemList(this DataTable table)
        {
            return table.AsEnumerable().Select(row =>
            {
                var item = new StringItem(row.Field<string>("Name"));
                foreach (var lang in StringItem.LanguageNames)
                    item.Languages[lang] = row.Field<string>(lang);
                return item;
            }).ToList();
        }
    }
