    public class MyClass{
        public string Date{get; set;} //DateTime is a better type to use for dates by the way
        public string Value2{get; set;}
        public string Value3{get; set;}
        public string Value4{get; set;}
        public string Value5{get; set;}
    }
    
    ...
    
    var sortedDateList = x1.OrderBy(x => x.Date).ToList()
