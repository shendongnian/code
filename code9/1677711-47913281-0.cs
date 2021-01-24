    public static class ThreadExtensions
    {
        public static IQueryable<Thread> GetThreadAsQueryable(this DbSet<Thread> table)
        {
            return table.Where(x => x.Comments.Where(x => x.Comment_CommentId == null));
        }
    }
    using (var context = new SampleDbContext())
    {
         var str = context.Thread.GetThreadAsQueryable().ToList();
    }
