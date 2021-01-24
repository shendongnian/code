            DataTable dt = new DataTable();
            dt.Columns.Add("emails");
            dt.Rows.Add("jane@doe.com");
            dt.Rows.Add("mike@foo.com");
            dt.Rows.Add("donald@duck.com");
            var authorized = dt.AsEnumerable().Any(s => s[0].Equals("mike@foo.com")); //returns True
            var notAuthorized = dt.AsEnumerable().Any(s => s[0].Equals("harry@houdini.com"));  //returns False
