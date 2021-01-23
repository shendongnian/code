    public class BazarInsertViewModel
    {
        public int SelectedCategoryId { get; set; }
        public SelectList MyCategory { get; set; }
    }
    public class SelectListItem
    {
        public string Value { get; set; }
        public string Text { get; set; }
    }
