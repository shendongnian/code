    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
    
            Activities = new HashSet<Activity>();
        }
    
        [Required]
        [Display(Name = "Voornaam")]
        public string FirstName { get; set; }
    
        [Required]
        [Display(Name = "Achternaam")]
        public string LastName { get; set; }
    
        public virtual ICollection<SignUp> SignUps { get; set; }
    }
