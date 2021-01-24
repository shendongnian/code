    abstract class Common
    {
        public string String1 {get; set;}
        public string string2 {get; set;}
        public double Threshold {get; set;} 
    }
    class Table1 : Common
    {
         public int Id {get; set;}
         ...
    }
    class Table2 : Common
    {
         public int Id {get; set;}
         ...
    }
