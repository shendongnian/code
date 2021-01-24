    public class User : IdentityUser
    {
        public virtual ICollection<UserLocation> Locations { get; set; }
        // Other code for Identity Framework
    }
