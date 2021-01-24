    public class ClientViewModel
    {
        [Required, DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        [Required]
        public int Age { get; set; }
    }
