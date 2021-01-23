    public class Diary
    {
        [Key]
        public int IdDiary { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string NameDiary { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CreationDate { get; set; }
        public bool Locked { get; set; }
        public virtual ICollection<Entry> Entries { get; set; }
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "This field is required")]
        public string Summary { get; set; }
        public string ImageUrl { get; set; }
        public ICollection<Tag> Tags { get; set; }
    }
