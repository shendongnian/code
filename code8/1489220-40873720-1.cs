    public class ApplicationUser : IdentityUser
    {
        public List<Store> StoreAdmin { get; set; }
        public List<Store> StoreManager { get; set; }
        ...
    }
