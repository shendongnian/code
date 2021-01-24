    public class UserViewModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public List<RoleViewModel> RoleViewModels { get; set; }
        public bool DeleteUser { get; set; } // Doesn't work yet, might be in the wrong place
    }
