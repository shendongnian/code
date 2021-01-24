            DataTable dt = new DataTable();
            dt.Columns.Add("emails");
            dt.Rows.Add("jane@doe.com");
            dt.Rows.Add("mike@foo.com");
            dt.Rows.Add("donald@duck.com");
            var result1 = dt.AsEnumerable().Any(s => s[0].Equals("mike@foo.com")); //returns True
            var result2 = dt.AsEnumerable().Any(s => s[0].Equals("harry@houdini.com"));  //returns False
