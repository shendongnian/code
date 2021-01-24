            DataTable dt = new DataTable();
            // define structure
            dt.Columns.Add("Column1");
            dt.Columns.Add("Column2");
            // ....
            dt.Columns.Add("ColumnN");
            // Add rows like this:
            dt.Rows.Add(new object[] { "Column1 value", "Column2 value", .. , "ColumnN value" });
