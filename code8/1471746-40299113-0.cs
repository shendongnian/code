            DataTable dt = new DataTable();
            DataColumn dc1 = new DataColumn("a", typeof(string));
            DataColumn dc2 = new DataColumn("b", typeof(int));
            dt.Columns.Add(dc1); dt.Columns.Add(dc2);
            dt.Rows.Add(new object[] { "sdfs", 23 });
            dt.Rows.Add(new object[] { "adbc", 5 });
            //The following part does the copying
            DataColumn dc3 = new DataColumn("c", typeof(int));
            dt.Columns.Add(dc3);
            foreach (DataRow dr in dt.Rows) dr.SetField<int>("c", dr.Field<int>("b"));
            
            dataGridView1.DataSource = dt.DefaultView;
