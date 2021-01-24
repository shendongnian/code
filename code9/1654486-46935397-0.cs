    public class Subject
    {
        public Subject()
        {
            Marks = new List<Mark>();
            Categories = new List<Category>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Teacher { get; set; }
    
        public ICollection<Mark> Marks { get; set; }
    
        public ICollection<Category> Categories { get; set; }
    }
    
    public class Category
    {
        public Category()
        {
            Marks = new List<Mark>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        public ICollection<Mark> Marks { get; set; }
    }
    
    public class Mark
    {
        public int Id { get; set; }
        public int SubjectId { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
    
        public Category Category { get; set; }
        public Subject Subject { get; set; }
    }
