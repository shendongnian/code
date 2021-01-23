    public class RoleSelectionViewModel
    {
        public ICollection<Role> Roles { get; set; } //list of all roles existing in your db for the columns
        public ICollection<UserDetails> Users {get; set;} //list of all users for which you want to set roles
    }
