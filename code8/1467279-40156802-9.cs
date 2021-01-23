    class Test
    {
        public string TestString { get; set; }
        public int TestInt { get; set; }
    }
    
    class Program
    {
        static void Main()
        {
            DataTable table = new DataTable();
            table.Columns.Add(new DataColumn("TestString", typeof(string)));
            table.Columns.Add(new DataColumn("TestInt", typeof(int)));
            for(int i = 0; i < 1000000; i++)
            {
                var row = table.NewRow();
                row["TestString"] = $"String number: {i}";
                row["TestInt"] = i;
                table.Rows.Add(row);
            }
            var stopwatch = Stopwatch.StartNew();
            var myList = table.DataTableToList<Test>();
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed.ToString());
        }
    }
