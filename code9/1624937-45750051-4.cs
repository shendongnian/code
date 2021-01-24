    class Category
    {
        public int Id {get; set;}
        // every Category has zero or more Adds:
        public virtual ICollection<Ad> Ads {get; set;}
        ...
    }
    class Ad
    {
        public int Id {get; set;}
        // every Ad belongs to exactly one Category, using foreign key CategoryId:
        public int CategoryId {get; set;}
        public Category Category {get; set;}
        ...
    }
