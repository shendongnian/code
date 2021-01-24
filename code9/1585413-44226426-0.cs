    public class Category
    {
        public virtual int CategoryId { get; set; }
        public virtual string CategoryName { get; set; }
        public virtual Category ParentCategory { get; set; }
        private ISet<Category> childCategory = new HashSet<Category>();
        public virtual ISet<Category> ChildCategory { get { return childCategory; } }
    }
