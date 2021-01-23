    public class Categories
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int AtpID { get; set; }
        public virtual ICollection<SubCategories> SubCategories { get; set; }
    }
    public class SubCategories
    {
        public int ID { get; set; }
        public string Name { get; set; }
        [ForeignKey("CategoryID")]
        public Categories Category { get; set; }
        public int CategoryID { get; set; }
        public string LinkToProducts { get; set; }
    }
