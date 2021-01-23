                 DataTable dt = new DataTable();
                 dt.Columns.Add("id", typeof(int));
                 dt.Columns.Add("parent", typeof(int));
                 dt.Rows.Add(new object[] { 1,0});
                 dt.Rows.Add(new object[] { 2,0});
                 dt.Rows.Add(new object[] { 3,1});
                 dt.Rows.Add(new object[] { 4,3});
                 dt.Rows.Add(new object[] { 5,2});  
