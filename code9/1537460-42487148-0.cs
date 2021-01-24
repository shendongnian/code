    public abstract class NumberTableModel
    {
        [Key]
        public int RowID { get; }
    
        public int SensorID { get; }
        public DateTime ReadingDate { get; }
        public int ReadingCount { get; }
        public float ApproxDataSize { get; }
        public Time ReadingTime { get; }
        public string JsonData { get; }
        public long LastUpdate { get; }
        public string Source { get; }
    }
    public class NumberTableModel1 : NumberTableModel { }
    
    public class NumberTableModel2: NumberTableModel { }
    
    public class NumberTableModel3: NumberTableModel { }
