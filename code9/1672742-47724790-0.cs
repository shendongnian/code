    public class RowVM
    {
        // Properties for each column
        public int Tahun { get; set; }
        public int Sementara { get; set; }
        public int Tetap { get; set; }
    }
    public class TableVM
    {
        public Enumerable<RowVM> Rows { get; set; }
        .... // other properties as required to represent the table header, footer etc
    }
