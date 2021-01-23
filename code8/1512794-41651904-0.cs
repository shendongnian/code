    public class Table2ViewModel
    {
        public string Column1 { get; set; }
    }
    public class BothTables
    {
        public int Id { get; set; }
        public IEnumerable<table1> TableOne{ get; set; }
        public IEnumerable<table2> TableTwo{ get; set; }
        public Table2ViewModel Table2 { get; set; }
    }
