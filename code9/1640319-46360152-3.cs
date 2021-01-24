        static void Main()
        {
            DataSet ds = new DataSet();
            DataTable dt = new FooBar.FooDataTable();
            ds.Tables.Add(dt);
            DataRow dr1 = dt.NewRow();
            dr1["A"] = 3;
            dr1["B"] = 4;
            dt.Rows.Add(dr1);
            DataRow dr2 = dt.NewRow();
            dr2["A"] = 1;
            dr2["B"] = 2;
            dt.Rows.Add(dr2);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Console.WriteLine(dr["A"] + " " + dr["B"]);
            }
            ds.Tables[0].DefaultView.Sort = "A";
            DataTable dvDT = ds.Tables[0].DefaultView.ToTable();
            foreach (DataRow dr in dvDT.Rows)
            {
                Console.WriteLine(dr["A"] + " " + dr["B"]);
            }
            Console.Read();
        }
