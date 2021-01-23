    public class Store : EntityModel
    {
        public List<ApplicationUser> Administrators { get; set; }
        public List<ApplicationUser> Managers{ get; set; }
        ...
    }
