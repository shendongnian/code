    public class Category
        {
            private ISet<Category> childCategories;
            private Category parentCategory;
    
            public Category()
            {
                childCategories = new HashSet<Category>();
            }
    
            public virtual int CategoryId { get; protected set; }
    
            public virtual string CategoryName { get; set; }
    
            public virtual ReadOnlyCollection<Category> ChildCategories
            {
                get
                {
                    return new ReadOnlyCollection<Category>(new List<Category>(childCategories));
                }
            }
    
            public virtual Category ParentCategory
            {
                get
                {
                    return parentCategory;
                }
            }
    }
