    public class TagModel
    {
        //well store our selection here
        public IList<string> SelectedTags { get; set; }
        //well load tags in here for selection
        public IList<SelectListItem> AvailableTags { get; set; }
        public TagModel()
        {
            SelectedTags = new List<string>();
            AvailableTags = new List<SelectListItem>();
        }
    }
