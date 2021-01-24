    public class ViewModelCategoryWithTitle
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
    public class ViewModelProduct
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Info { get; set; }
        public decimal Price { get; set; }
        public int SortOrder { get; set; }
        public IEnumerable<ViewModelCategoryWithTitle> Categories { get; set; }
    }
    
