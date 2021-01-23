    public class AccountSetting 
    {
        [Key]
        public int AccountSettingID { get; set; }
        [Required]
        public int AccountID { get; set; }
        [Required, ForeignKey("AccountID ")]
        public virtual Account Account { get; set; }
    }
