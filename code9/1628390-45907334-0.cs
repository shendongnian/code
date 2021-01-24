        public class Option
        {
             public string Name { get; set; }
             public string Value { get; set; }
        }
        public class Header
        {
            public DateTime Time { get; set; }
            public string ReportName { get; set; }
            public string ReportBasis { get; set; }
            public string StartPeriod { get; set; }
            public string EndPeriod { get; set; }
            public string SummarizeColumnsBy { get; set; }
            public string Currency { get; set; }
            public IList<Option> Option { get; set; }
        }
    
        public class MetaData
        {
            public string Name { get; set; }
            public string Value { get; set; }
        }
    
        public class Column
        {
            public string ColTitle { get; set; }
            public string ColType { get; set; }
            public IList<MetaData> MetaData { get; set; }
        }
    
        public class Columns
        {
            public IList<Column> Column { get; set; }
        }
    
        public class ColData
        {
             public string value { get; set; }
             public string id { get; set; }
        }
     
        public class ColData
        {
             public string value { get; set; }
             public string id { get; set; }
        }
     
        public class Row
        {
            public IList<ColData> ColData { get; set; }
            public string type { get; set; }
        }
    
        public class Rows
        {
            public IList<Row> Row { get; set; }
        }
        public class ColData
        {
            public string value { get; set; }
        }
    
        public class Summary
        {
            public IList<ColData> ColData { get; set; }
        }
    
        public class ColData
        {
            public string value { get; set; }
            public string id { get; set; }
        }
    
        public class Row
        {
            public  Header { get; set; }
            public Rows Rows { get; set; }
            public Summary Summary { get; set; }
            public string type { get; set; }
            public IList<ColData> ColData { get; set; }
        }
    
        public class Rows
        {
            public IList<Row> Row { get; set; }
        }
    
        public class Row
        {
            public IList<ColData> ColData { get; set; }
            public string type { get; set; }
            public  Header { get; set; }
            public Rows Rows { get; set; }
            public  Summary { get; set; }
        }
     
        public class Rows
        {
            public IList<Row> Row { get; set; }
        }
    
        public class Row
        {
            public  Header { get; set; }
            public Rows Rows { get; set; }
            public  Summary { get; set; }
            public string type { get; set; }
            public string group { get; set; }
        }
    
        public class Rows
        {
            public IList<Row> Row { get; set; }
        }
    
        public class Example
        {
            public Header Header { get; set; }
            public Columns Columns { get; set; }
            public Rows Rows { get; set; }
        }
    
