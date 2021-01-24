    public enum BatchType
    {
        Scanned = 1,
        NonScanned = 2
    }
    public enum RecType
    {
        Adc = 1,
        NotAdc = 2
    }
    public class Batch
    {
        public int BatchCode { get; set; }
        public BatchType BatchType { get; set; }
        public double Amount { get; set; }
        public RecType RecType { get; set; }
    }
    public class BatchGroup
    {
        public int BatchCode { get; set; }
        public BatchType BatchType { get; set; }
        public int DetailRecordCountAdc { get; set; }
        public int DetailRecordCountNotAdc { get; set; }
        public int DetailRecordCountTotal => DetailRecordCountAdc + DetailRecordCountNotAdc;
        public double AmountAdc { get; set; }
        public double AmountNotAdc { get; set; }
        public double AmountTotal => AmountAdc + AmountNotAdc;
    }
