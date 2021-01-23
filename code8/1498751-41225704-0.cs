    public void Insert(string tablename ,string[] values, string[] columns)
        {
            string val =  "VALUES"+"(";
            foreach (var value in values)
            {
                if (values.Length > 1)
                    val += values + ",";
                if (values == null)
                    val = "";
                else val += values;
            }
            val += ")";
            string col = "(";
            foreach (var column in columns)
            {
                if (columns.Length > 1)
                    col += columns + ",";
                if (columns == null)
                    col = "";
                else col += columns;
            }
            col += ")";
