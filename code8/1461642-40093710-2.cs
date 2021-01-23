    class Program
    {
        static void Main(string[] args)
        {
            var ctx = new Context();
            ctx.Database.CreateIfNotExists();
            Console.ReadKey();
        }
    }
    public class Context : DbContext
    {
        public Context():base ("Teste")
        {
        }
        public DbSet<ContentExternalLink> ContentExternalLinks { get; set; }
        public DbSet<ContentTagAssignment> ContentTagAssignments { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ContentExternalLinkMap());
            modelBuilder.Configurations.Add(new ContentTagAssignmentMap());
            base.OnModelCreating(modelBuilder);
        }
    }
    public class ContentExternalLink
    {
        public ContentExternalLink()
        {
            ContentTagAssignments = new List<ContentTagAssignment>();
        }
        [Key]
        public string LinkId { get; set; }
        public string LinkTypeId { get; set; }
        public string LinkTitle { get; set; }
        public string LinkUrl { get; set; }
        public string LinkSource { get; set; }
        public string LinkPhoneNumber { get; set; }
        public DateTime LinkDate { get; set; }
        public DateTime LinkCreatedDate { get; set; }
        public DateTime LinkModifiedDate { get; set; }
        
        public virtual ICollection<ContentTagAssignment> ContentTagAssignments { get; set; }
    }
    public class ContentTagAssignment
    {
        public ContentTagAssignment()
        {
            this.ContentExternalLink = new ContentExternalLink();
        }
        [Key]
        public string TagId { get; set; }
        [Key]
        public string ArticleId { get; set; }
        public string LinkId { get; set; }
        public bool IsPrimary { get; set; }
        public DateTime CreatedDate { get; set; }
        
        public virtual ContentExternalLink ContentExternalLink { get; set; }
    }
    public class ContentExternalLinkMap : EntityTypeConfiguration<ContentExternalLink>
    {
        public ContentExternalLinkMap()
        {
            this.ToTable("content_external_link", "dbo");
            this.HasKey(c => c.LinkId);
            this.Property(c => c.LinkId).HasColumnName("link_id");
            this.Property(c => c.LinkTypeId).HasColumnName("link_type_id");
            this.Property(c => c.LinkTitle).HasColumnName("link_title");
            this.Property(c => c.LinkUrl).HasColumnName("link_url");
            this.Property(c => c.LinkSource).HasColumnName("link_source");
            this.Property(c => c.LinkPhoneNumber).HasColumnName("link_phone_number");
            this.Property(c => c.LinkDate).HasColumnName("link_date");
            this.Property(c => c.LinkCreatedDate).HasColumnName("link_created_date");
            this.Property(c => c.LinkModifiedDate).HasColumnName("link_modified_date");
        }
    }
    public class ContentTagAssignmentMap : EntityTypeConfiguration<ContentTagAssignment>
    {
        public ContentTagAssignmentMap()
        {
            this.ToTable("content_tag_assignment", "dbo");
            this.HasKey(t => new { t.TagId, t.ArticleId });
            this.Property(t => t.TagId).HasColumnName("tag_id");
            this.Property(t => t.ArticleId).HasColumnName("article_id");
            this.Property(t => t.IsPrimary).HasColumnName("is_primary_tag");
            this.Property(t => t.CreatedDate).HasColumnName("created_date");
            this.HasOptional(t => t.ContentExternalLink)
                .WithMany(t => t.ContentTagAssignments)
                .HasForeignKey(t => t.LinkId)
                .WillCascadeOnDelete(false);
        }
    }
