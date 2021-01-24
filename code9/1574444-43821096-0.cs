    public class Personal {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PersonalId {get;set;}
        public string PName {get;set;}
        public string PLastname {get;set;}
        public string PStatus {get;set;}
        public int ShopId {get;set;}
        [DataType(DataType.Password)]
        public string PPassword {get;set;}
        public string GenderID {get;set;}
        public DateTime? DOB  {get;set;}
        [EmailAddress]
        public string Email {get;set;}
        public DateTime? JobStartDate  {get;set;}
        public string PAuthorisation {get;set;}
        [DataType(DataType.PhoneNumber)]
        public string Phone {get;set;}
    }
