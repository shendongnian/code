    public class Category
    {
        public int CategoryId { get; set; }
        public IList<Article> Articles { get; set; }
    }
    public class Article
    {
        public int ArticleId { get; set; }
        public Category Category { get; set; }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>().HasOne(article => article.Category)
                .WithMany(category=> category.Articles);
        }
