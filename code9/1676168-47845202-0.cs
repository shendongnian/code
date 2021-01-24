    public class CustomUser : IUser<string>
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public void A(string a)
        {
            
        }
    }
    var customUser = new CustomUser();
    customUser.A("Sample");
