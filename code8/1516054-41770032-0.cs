    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Email_Key { get; set; }
        [NotMapped]
        public virtual UserInfo UserInfo
        {
            get
            {
                return new Context().UserInfoes.Single(u => u.EMAIL_KEY == Email_Key);
            }
        }
    }
