    public class MyTable
    {
        [Key, Column(Order = 0)]
        [Required(AllowEmptyStrings = false
        public string LanguageID { get; set; }
    
        [Key, Column(Order = 1)]
        [Required(AllowEmptyStrings = false
        public byte YearID { get; set; }
    
        [Key, Column(Order = 2)]
        [Required(AllowEmptyStrings = false)]
        public byte SIMSCodeID { get; set; }
    
        [Required(AllowEmptyStrings = true)]
        public string Data { get; set; }
    
        [Required(AllowEmptyStrings = true)]
        public int UserID { get; set; }
    
        [Required(AllowEmptyStrings = true)]
        public int brformula { get; set; }
        public MyTable()
        {
            brformula = 0;
        }
    }
