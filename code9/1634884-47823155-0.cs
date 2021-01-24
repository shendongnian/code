    public class MyApplicationUser : IdentityUser<int>
    {
        public virtual ICollection<MyApplicationUserJunction> MyApplicationUsers { get; set; }
        public virtual ICollection<MyApplicationUserJunction> ManagingMyApplicationUsers { get; set; }
    }
