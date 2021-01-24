    public class Language
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsApproved { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
    
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<CategoryTrans> Translations { get; set; }
    }
    
    public class CategoryTrans
    {
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public int LanguageId { get; set; }
        public virtual Language Language { get; set; }
        public string Name { get; set; }
    }
