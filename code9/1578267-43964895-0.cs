                DataTable dt = new DataTable("MyDataTable");
     
                dt.Columns.Add("A", typeof(int));
                dt.Columns.Add("B", typeof(int));
                dt.Columns.Add("C", typeof(int));
                dt.Columns["A"].AllowDBNull = true;
                dt.Columns["B"].AllowDBNull = true;
                dt.Columns["C"].AllowDBNull = true;
                dt.Rows.Add(new object[] { 1,2,3});
                dt.Rows.Add(new object[] { 2, 2, });
                dt.Rows.Add(new object[] { 3 });
             
                datagridview1.DataSource = dt;
