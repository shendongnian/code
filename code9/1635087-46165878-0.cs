    public class ManageViewModel
    {
        public IPagedList<Book> Inventory;
        [Display(Name = "Include old inventory")]
        public bool OldInventoryIsShown { get; set; }
        ... // any other search/filter properties
    }
