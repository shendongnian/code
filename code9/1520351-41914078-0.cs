        public static int fId(Foo f)
        {
            return f.Id;
        }
        public static Foo fPosts(Foo f)
        {
            return f;
        }
        public static User fSelect(int k, IEnumerable<Foo> v )
        {
            return new User()
            {
                UserId = k,
                Name = v.FirstOrDefault().Name,
                Posts = v.Select(f => new Post()
                {
                    Id = f.Id,
                    Title = f.Title,
                    Content = f.Content
                })
            };
    var groupedPosts = userposts.GroupBy(fId, fPosts, fSelect);
