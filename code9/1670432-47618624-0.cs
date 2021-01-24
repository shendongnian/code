        public class JSON
        {
            public string name { get; set; }
    
            public string[] ColumnSelect { get; set; }
    
            public string[] sort { get; set; }
    
            public filterList filterList { get; set; }
        }
    
        public class filterList
        {
            public string Attribute { get; set; }
    
            public string Operator { get; set; }
    
            public string[] Value { get; set; }
        }
