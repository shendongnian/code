    class Program
    {
        static void Main(string[] args)
        {
            var result = LoadComment(1, null);
            Console.ReadKey();
    
        }
    
        public static Comment LoadComment(long id, Comment com)
        {
            if (com == null)
            {
                // You would call your context here and write db.Single(x => x.Id == id).Include(x => x.User.Avatar);
                var first = db.Single(x => x.Id == id); 
    
                res = new Comment { Id = first.Id, Replies = first.Replies.ToList(), User = first.User };
                foreach (var item in first.Replies)
                {
                    LoadComment(item.Id, res);
                }
            }
            else
            {
                // You would call your context here and write db.Single(x => x.Id == id).Include(x => x.User.Avatar);
                var child = db.SingleOrDefault(x => x.Id == id); 
                if (child == null)
                {
                    return null;
                }
    
                com.Replies.Add(new Comment { Id = child.Id, Replies = child.Replies.ToList(), User = child.User });
                foreach (var item in child.Replies)
                {
                    LoadComment(item.Id, com);
                }
            }
    
    
            return res;
        }
    
        private static Comment cm1 = new Comment
        {
            Id = 1,
            User = new User { Id = 1, Avatar = new Avatar { Url = "1" } },
            Replies = new List<Comment> {
            new Comment { Id = 2 },
            new Comment { Id = 3 },
            new Comment { Id = 4 },
            new Comment { Id = 5 } },
            Content = "ContentForCommentId1"
        };
    
        private static Comment cm2 = new Comment
        {
            Id = 2,
            User = new User { Id = 2, Avatar = new Avatar { Url = "2" } },
            Replies = new List<Comment> {
            new Comment { Id = 22 },
            new Comment { Id = 33 },
            new Comment { Id = 44 },
            new Comment { Id = 55 } },
            Content = "ContentForCommentId2"
        };
        private static List<Comment> db = new List<Comment> { cm1, cm2 };
        private static Comment res = new Comment();
    }
