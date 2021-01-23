            var dt = new DataTable();
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("value");
            dt.Rows.Add(1, "test1");
            dt.Rows.Add(2, "test2");
            dt.Rows.Add(3, "test3");
            dt.Rows.Add(4, "test4");
            int[] idfilter = new[] { 2, 4 };
            var filteredrows = dt.AsEnumerable().Where(f => idfilter.Contains(f.Field<int>("id")));
            foreach (var row in filteredrows)
                Console.WriteLine(row["id"]);
            Console.ReadLine();
