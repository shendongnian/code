    public class InterestCategoryModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<InterestModel> Interests { get; set; }
        
        public class InterestModel
        {
            public long Id { get; set; }
            public string Name { get; set; }
        }
    }
    public class InterestModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public InterestCategoryModel InterestCategory { get; set; }
        
        public class InterestCategoryModel
        {
            public long Id { get; set; }
            public string Name { get; set; }
        }
    }
