    public class Entry
    {
        [Key]
        public int IdEntry { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CreationDate { get; set; }
        [DataType(DataType.MultilineText)]
        public string EntryText { get; set; }
        [ForeignKey("Diary_IdDiary")]
        public virtual Diary Diary { get; set; }
        public int Diary_IdDiary { get; set; }
        public string EntryName { get; set; }
    }
