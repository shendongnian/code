    public partial class Register
    {
        public Register()
        {
            this.Role = new Role();
        }
        public int Id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public Nullable<int> phone_no { get; set; }
    
        public virtual Role Role { get; set; }
    }
