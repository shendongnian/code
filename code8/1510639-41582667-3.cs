    public class UserModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    
        // This will be the selected profile id
        public string SelectedProfileId { get; set; }
    
        // fill this with all the profiles
        public IEnumerable<SelectListItem> AvailableProfiles { get; set; }
    }
