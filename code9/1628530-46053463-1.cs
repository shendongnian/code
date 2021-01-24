    public class ApplicationUser : IdentityUser
    {
        //Here you can add more properties if you wish to
        public string FirstName{ get; set; }
        public string LastName { get; set; }
    
        //User-Item relationship (user can have many Items)
        public virtual List<Item> Items { get; set; }
    }
