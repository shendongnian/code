    public class ProductFilterVM
    {
        public string Name { get; set; }
        ... // other properties relating to a product that you may want to display the view - e.g. Description
        public IEnumerable<FilterCategoryVM> FilterCategories { get; set; }
    }
    public class FilterCategoryVM
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<FilterSelectionVM> Selections { get; set; }
    }
    public class FilterSelectionVM
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
