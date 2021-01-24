    public class ClaimConfiguration : EntityTypeConfiguration<Claim>
    {
        public ClaimConfiguration()
        {
            HasKey( e => e.Id );
            Property( e => e.Name )
                .IsRequired( )
                .HasMaxLength( 100 );
        }
    }
    public class ForumThreadConfiguration : EntityTypeConfiguration<ForumThread>
    {
        public ForumThreadConfiguration()
        {
            HasKey( e => e.Id );
            Property( e => e.Name )
                .IsRequired( )
                .HasMaxLength( 100 );
        }
    }
    public class CommentDiscussionConfiguration : EntityTypeConfiguration<CommentDiscussion>
    {
        public CommentDiscussionConfiguration()
        {
            HasKey( e => e.Id );
            HasOptional( e => e.Claim )
                .WithRequired( m => m.CommentDiscussion )
                .Map( cfg => cfg.MapKey( nameof( CommentDiscussion.ClaimId ) ) );
            HasOptional( e => e.ForumThread )
                .WithRequired( m => m.CommentDiscussion )
                .Map( cfg => cfg.MapKey( nameof( CommentDiscussion.ForumThreadId ) ) );
        }
    }
