                DataTable dt = new DataTable();
                dt.Columns.Add("id", typeof(int));
                dt.Columns.Add("firstname", typeof(string));
                dt.Columns.Add("lastname", typeof(string));
                dt.Rows.Add(new object[] { 1,"John", "Smith"});
                dt.Rows.Add(new object[] { 2, "Mary", "Jones" });
                dt.Rows.Add(new object[] { 3, "Harry", "James" });
