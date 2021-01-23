    public class UserViewModel
    {
        public Users users { get; set; }                
        public IEnumerable<SelectListItem> UserRoles { get; set; }                    
        public string selectedRole { get; set; }
    }
