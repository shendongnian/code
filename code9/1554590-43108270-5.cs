            DataTable dtMain = new DataTable();
            dtMain.Columns.Add("C1", typeof(string));
            dtMain.Columns.Add("C2", typeof(string));
            dtMain.Columns.Add("C3", typeof(string));
            dtMain.Rows.Add(new object[] { "1", "test1", "test1" });
            dtMain.Rows.Add(new object[] { "2", "test2", "test2" });
            dtMain.Rows.Add(new object[] { "3", "test3", "test3" });
            DataTable dtChild = dtMain.Clone();
            dtChild = dtMain.AsEnumerable()
                            .Where(x => x.Field<string>("C2") != "test2")
                            .Select(x=> x).CopyToDataTable();
            foreach (DataRow dr in dtChild.Rows)
            {
                Console.WriteLine(dr["C1"].ToString());
                Console.WriteLine(dr["C2"].ToString());
                Console.WriteLine(dr["C3"].ToString());
            } 
