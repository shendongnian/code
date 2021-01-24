    public class EditUserViewModel
    {
        public EditUserViewModel()
        {
            this.GroupsList = new List<SelectListItem>();
        }
        // Add a GroupsList Property:
        public ICollection<SelectListItem> GroupsList { get; set; }
        
        //other properties
    }
