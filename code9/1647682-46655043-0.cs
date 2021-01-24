       public class Rootobject
            {
                public int id { get; set; }
                public string name { get; set; }
                public Category category { get; set; }
                public string description { get; set; }
            }
    
            public class Category
            {
                public int id { get; set; }
                public string name { get; set; }
                public Subcategory subcategory { get; set; }
            }
    
            public class Subcategory
            {
                public int id { get; set; }
                public string name { get; set; }
            }
