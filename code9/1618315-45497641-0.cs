    public class FileIdSeq
    {
        [Key]
        public DateTime SequenceDate { get; set; }
        [DefaultValue(1)]
        public int LastSequence { get; set; }
    }
