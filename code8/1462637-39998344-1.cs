     using (SqlCeConnection conn =
        new SqlCeConnection(@"Data Source=C:\data\AdventureWorks.sdf;"))
     {
         conn.Open();
         using (SqlCeTransaction tx = conn.BeginTransaction(IsolationLevel.ReadCommitted))
         {
             using (var context =  new BloggingContext(conn, contextOwnsConnection: false)) 
             { 
                context.Database.UseTransaction(tx); 
                var query =  context.Posts.Where(p => p.Blog.Rating >= 5); 
                foreach (var post in query) 
                { 
                   post.Title += "[Cool Blog]"; 
                } 
                context.SaveChanges(); 
            }
            tx.Commit(CommitMode.Immediate); 
         }
    }
