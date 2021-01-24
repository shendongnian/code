        public class Table
        {
            public string Entity { get; set; }
            public int Period { get; set; }
            public string Level { get; set; }
            public string Process { get; set; }
            public string Corporate { get; set; }
        }
    var list = dataTable.ToList<Table>();
    var jsonString = JsonConvert.SerializeObject(list)
