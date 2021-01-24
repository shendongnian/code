    namespace C2T.Models
    {
        public class Organisation
        {
            public int OrganisationId { get; set; }
    
            // Whatever other fields you want
            public string NameOrOtherField { get; set; }
    
            public virtual ICollection<ApplicationUser> ApplicationUsers { get; set; }
        }
    }
