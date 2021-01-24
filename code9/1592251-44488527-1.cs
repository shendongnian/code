    public class ApplicationUser : IdentityUser
    {
        [NotMapped]
        public override bool EmailConfirmed { get => base.EmailConfirmed; set => base.EmailConfirmed = value; }
        // etc.
    }
