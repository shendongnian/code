        static void Main(string[] args)
        {
            DataTable d = new DataTable();
            d.Columns.Add("ItemName", typeof(int));
            d.Columns.Add("MinValue", typeof(float));
            d.Columns.Add("MaxValue", typeof(float));
            d.Rows.Add(1, 0.1, 0.2);
            d.Rows.Add(1, 0.2, 0.4);
            d.Rows.Add(1, 0.1, 0.2);
            var dataTable = d.AsEnumerable();
            var data = dataTable.Select(x => x[0]).ToList();
            Console.WriteLine($"{data.Count}");
            Console.ReadLine();
        }
