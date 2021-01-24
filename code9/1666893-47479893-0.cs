    public class AddOfferAnnounceModel
    {
        public List<SelectListItem> Items { set;get;}  // These 2 properties for the dropdown
        public int SelectedItem { set;get;}
        public int Surface { get; set; }
    
        [Required]
        public decimal Price { get; set; }
    
        public string AnnounceDetails { get; set; }
    
        public bool Net { get; set; }
    }
