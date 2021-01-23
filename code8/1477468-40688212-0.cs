    public class SeeAlso
    {
        public List<int> SelectedCategories { get; set; }
        public List<SubCategories> AvailableCategories { get; set; }
    }
    public class SubCategories
    {
        public int Id { get; set; }
        public string SubCategoryName { get; set; }
        public int CategoryId { get; set; }
    }
