     public class User
        {
            public User(int id)
            {
                Id = id;
            }
            public int Id { get; set; }
        }
    
        public class Image
        {
            public int Id { get; set; }
            public List<User> Users { get; set; }
        }
    .......
    
         public List<Tuple<int, int>> OrderByUser(IList<Image> cursos)
                {
                     var data = cursos.SelectMany(x => x.Users
                    .Select(p => new { image = x, user = p }))
                    .GroupBy(x => x.user.Id)
                    .Select(x => new { userId = x.Key, total = x.Count() })
                    .OrderByDescending(x => x.total)
                    .Take(3);
                data = data.OrderByDescending(x => x.total);
                return data.Select(x=> new Tuple<int, int>(x.userId, x.total)).ToList();
                }
    
    
    
