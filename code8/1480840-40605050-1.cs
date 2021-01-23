    public class SubCategories
    {
        public int ID { get; set; }
        public string Name { get; set; }
        [ForeignKey("CategoryID")]
        public Categories Category { get; set; }
        public int CategoryID { get; set; }
        public string LinkToProducts { get; set; }
    }
