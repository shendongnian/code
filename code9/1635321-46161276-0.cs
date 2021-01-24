    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data;
    using System.Diagnostics;
    
    namespace Ef6Test
    {
    
        public class Post
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public virtual ICollection<Vote> Votes { get; } = new HashSet<Vote>();
        }
        public class Vote
        {
            public int Id { get; set; }
            public Post Post { get; set; }
    
        }
    
        public class PostDto
        {
            public string Title { get; set; }
            public int VoteCount { get; set; }
        }
        class Db : DbContext
        {
    
    
            public DbSet<Post> Posts { get; set; }
            public DbSet<Vote> Votes { get; set; }
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);
            }
    
            
            
    
        }
    
        class Program
        {
    
    
            static void Main(string[] args)
            {
    
            
    
                Database.SetInitializer(new DropCreateDatabaseAlways<Db>());
    
    
                using (var db = new Db())
                {
                    db.Database.Log = m => Console.WriteLine(m);
                    db.Database.Initialize(false);
    
                    var posts = db.Posts.Select(p => new PostDto { Title = p.Title, VoteCount = p.Votes.Count }).ToList();
    
    
                    
                }
    
                Console.WriteLine("Hit any key to exit");
                Console.ReadKey();
            }
        }
    }
