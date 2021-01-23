    public class User : IdentityUser
    {
        public int CompanyId { get; set; }        
        public virtual Person Person { get; set; }
        //other stuff....
    }
