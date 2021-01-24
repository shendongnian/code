    using ( var context = new ModelContext() )
    {
        CommentDiscussion discussion = new CommentDiscussion( );
        context.Set<CommentDiscussion>( ).Add( discussion );
        try
        {
            context.SaveChanges( );
        }
        catch ( Exception ex )
        {
            Console.WriteLine( ex.ToString() );
        }
        Claim claim = new Claim( );
        ForumThread forumThread = new ForumThread( );
        claim.CommentDiscussion = discussion;
        forumThread.CommentDiscussion = discussion;
        try
        {
            context.SaveChanges( );
        }
        catch ( Exception ex )
        {
            Console.WriteLine( ex.ToString( ) );
        }
    }
