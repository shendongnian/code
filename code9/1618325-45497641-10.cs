     public class PatReg
    {
        [NotMapped]
        private Int64 _FileId;
        [Key, Display(Name = "File Id"), ScaffoldColumn(false), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Int64 FileId
        {
            get
            {
                return this._FileId;
            }
            set
            {
                this._FileId = value;
            }
        }
        [Required, Display(Name = "First Name")]
        public string FName { get; set; } 
        [Required, Display(Name = "Middle Name")]
        public string MName { get; set; }
        [Required, Display(Name = "Last Name")]
        public string LName { get; set; }
        [Required, Display(Name = "Date of Birth"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Dob { get; set; }
        
    }
