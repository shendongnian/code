    public class ModelContext : DbContext
    {
        // Der Kontext wurde für die Verwendung einer ModelContext-Verbindungszeichenfolge aus der
        // Konfigurationsdatei ('App.config' oder 'Web.config') der Anwendung konfiguriert. Diese Verbindungszeichenfolge hat standardmäßig die
        // Datenbank 'ConsoleApp7.Model.ModelContext' auf der LocalDb-Instanz als Ziel.
        //
        // Wenn Sie eine andere Datenbank und/oder einen anderen Anbieter als Ziel verwenden möchten, ändern Sie die ModelContext-Zeichenfolge
        // in der Anwendungskonfigurationsdatei.
        public ModelContext()
            : base( "name=ModelContext" )
        {
        }
        protected override void OnModelCreating( DbModelBuilder modelBuilder )
        {
            modelBuilder.Configurations.Add( new ClaimConfiguration( ) );
            modelBuilder.Configurations.Add( new ForumThreadConfiguration( ) );
            modelBuilder.Configurations.Add( new CommentDiscussionConfiguration( ) );
            base.OnModelCreating( modelBuilder );
        }
        protected override bool ShouldValidateEntity( DbEntityEntry entityEntry )
        {
            return base.ShouldValidateEntity( entityEntry );
        }
        protected override DbEntityValidationResult ValidateEntity( DbEntityEntry entityEntry, IDictionary<object, object> items )
        {
            if ( entityEntry.Entity is CommentDiscussion )
            {
                if ( !entityEntry.CurrentValues.GetValue<int?>( nameof( CommentDiscussion.ClaimId ) ).HasValue && !entityEntry.CurrentValues.GetValue<int?>( nameof( CommentDiscussion.ForumThreadId ) ).HasValue )
                {
                    var list = new List<System.Data.Entity.Validation.DbValidationError>( );
                    list.Add( new System.Data.Entity.Validation.DbValidationError( nameof( CommentDiscussion.Claim ), "Claim or ForumThread is required" ) );
                    list.Add( new System.Data.Entity.Validation.DbValidationError( nameof( CommentDiscussion.ForumThread ), "Claim or ForumThread is required" ) );
                    return new System.Data.Entity.Validation.DbEntityValidationResult( entityEntry, list );
                }
                if ( entityEntry.CurrentValues.GetValue<int?>( nameof( CommentDiscussion.ClaimId ) ).HasValue && entityEntry.CurrentValues.GetValue<int?>( nameof( CommentDiscussion.ForumThreadId ) ).HasValue )
                {
                    var list = new List<System.Data.Entity.Validation.DbValidationError>( );
                    list.Add( new System.Data.Entity.Validation.DbValidationError( nameof( CommentDiscussion.Claim ), "Only Claim or ForumThread is possible, not both" ) );
                    list.Add( new System.Data.Entity.Validation.DbValidationError( nameof( CommentDiscussion.ForumThread ), "Only Claim or ForumThread is possible, not both" ) );
                    return new System.Data.Entity.Validation.DbEntityValidationResult( entityEntry, list );
                }
            }
            return base.ValidateEntity( entityEntry, items );
        }
    }
