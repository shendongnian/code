    public class UserModel
    {
        public string userid { get; set; }
        public string userdesc { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime startdt { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime enddt { get; set; }
        public string status { get; set; }
    }
