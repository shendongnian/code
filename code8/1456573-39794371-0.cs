    public class SendGroupEmailViewModel
    {
        public int EmailID { get; set; }
        public IEnumerable<SelectListItem> Roles { get; set; }
        public string [] SelectedRoles { get; set; }
    }
