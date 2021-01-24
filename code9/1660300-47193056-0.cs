    public static class MyTableExtenstions
        {
            public static string[] AsStrings(this Table t, string column)
            {
                return t.Rows.Select(r => r[column]).ToArray();
            }
        }
