    public class ItemsWithTotal<T> // for pete sake find a better name!
    {
        public int Current {get; set; }
        public int RowCount {get; set; }
        public int Total {get; set; }
        public List<T> Rows {get; set; }
    }
