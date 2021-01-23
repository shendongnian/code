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
            this.HasRequired(t => t.ContentExternalLink)
                .WithMany(t => t.ContentTagAssignments)
                .HasForeignKey(t => t.ArticleId)
                .WillCascadeOnDelete(false);
        }
    }
