    public class MyViewModel
    {
        public MyViewModel()
        {
            this.DropdownItems = new List<SelectListItem>();
        }
        public int SelectedSiteId { get; set; }
        public List<SelectListItem> DropdownItems { get; set; }
    }
