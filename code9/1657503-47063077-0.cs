    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace EfDbFirstTest
    {
        public class Blog
        {
            public int Id { get; set; }
            public DateTime CreatedDate { get; set; }
            public string Author { get; set; }
            public string BlogTitle { get; set; }
            public string BlogDescription { get; set; }
            public ICollection<BlogMedia> BlogMedia { get; set; }
        }
    
        public class BlogMedia
        {
            public int Id { get; set; }
            public int BlogId { get; set; }
            public Blog Blog { get; set; }
            public string BlogPicturePath { get; set; }
        }
    
        public class Db : DbContext
        {
            public DbSet<Blog> Blogs { get; set; }
            public DbSet<BlogMedia> BlogMedia { get; set; }
        }
        class Program
        {
            static void Main(string[] args)
            {
    
    
                using (var db = new Db())
                {
                    db.Database.Log = m => Console.WriteLine(m);
    
                    var q = from b in db.Blogs
                            select new
                            {
    
                                b.Id,
                                b.CreatedDate,
                                b.Author,
                                b.BlogTitle,
                                b.BlogDescription,
                                BlogPicturePath = b.BlogMedia.Any() ? b.BlogMedia.OrderByDescending(m => m.Id).FirstOrDefault().BlogPicturePath : null
                            };
    
                    var results = q.ToList();
    
    
    
                    Console.ReadKey();
                }
            }
        }
    }
