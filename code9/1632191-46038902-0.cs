    public class ForumMember
    {
        public int Id { get; set; }
    }
    
    public class Member
    {
        public int MemberId { get; set; }
    }
    
    public class ThreadComment
    {
        public int CreatorUserId { get; set; }
    }
    
    public class ForumContext : DbContext
    {
        public DbSet<ForumMember> ForumMembers { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<ThreadComment> ThreadComments { get; set; }
    }
    
    public class Repository
    {
        public IEnumerable<Something> GetAllForumMember()
        {
            using (var context = new ForumContext())
            {
                var query = from fm in context.ForumMembers
                            join m in context.Members on fm.Id equals m.MemberId
                            //where add where clause
                            select new Something
                            {
                                memberId = m.MemberId,
                                commentCount = context.ThreadComments.Count(x => x.CreatorUserId == m.MemberId)
                                //... add other properties that you want to get.
                            };
                 return query.ToList();
                
            }
        }
    }
