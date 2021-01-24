    public class Category
    {
        public int CategoryId { get; set; }
        public int PrivilegeId { get; set; }
        
        public virtual ICollection<Privilege> Privilege { get; set; }
    }
    public class Privilege
    {
        public int PrivilegeId { get; set; }
        public int ObjectId { get; set; }
    }
    public class CategoryMap : EntityTypeConfiguration<Category>
    {
        public CategoryMap()
        {
            ToTable("Categories");
            HasKey(x => x.CategoryId);
            HasMany(x => x.Privilege)
                .WithMany()
                .Map(x =>
                {
                    x.MapLeftKey(nameof(Category.PrivilegeId));
                    x.MapRightKey(nameof(Privilege.ObjectId));
                });
        }
    }
    public class PrivilegeMap : EntityTypeConfiguration<Privilege>
    {
        public PrivilegeMap()
        {
            ToTable("Categories");
            HasKey(x => x.PrivilegeId);
        }
    }
