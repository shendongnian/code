    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.SqlClient;
    using System.Linq;
    
    namespace ConsoleApp8
    {
    
        public class User
        {
            public int UserId { get; set; }
            public string Name { get; set; }
            public virtual ICollection<Feature> Feaures { get; } = new HashSet<Feature>();
        }
        public class Feature
        {
            public int FeatureId { get; set; }
            public string Description { get; set; }
    
            public virtual ICollection<User> Users { get; } = new HashSet<User>();
        }
    
        class Db : DbContext
        {
            public DbSet<User> Users { get; set; }
            public DbSet<Feature> Features { get; set; }
    
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
            }
        }
    
    
    
        class Program
        {      
    
            static void Main(string[] args)
            {
    
    
                if (true)
                {
                    Database.SetInitializer(new DropCreateDatabaseAlways<Db>());
                    using (var db = new Db())
                    {
                        var features = Enumerable.Range(1, 20).Select(i => new Feature() { Description = $"Feature{i}" }).ToList();
    
                        var users = Enumerable.Range(1, 30000).Select(i => new User() { Name = $"User{i}" }).ToList();
                        var rand = new Random();
                        foreach (var u in users)
                        {
                            var featureCount = rand.Next(4, 5);
                            for (int i = 0; i < featureCount; i++)
                            {
                                u.Feaures.Add(features[rand.Next(0, features.Count - 1)]);
                            }
                        }
    
                        db.Users.AddRange(users);
                        db.Features.AddRange(features);
                        db.SaveChanges();
                    }
                }
    
                List<int> requestedFeatureIds;
                using (var db = new Db())
                {
                    db.Database.Log = m => Console.WriteLine(m);
                    var user = db.Users.Where(u => u.Feaures.Count() == 4).AsEnumerable().Last() ;
                    requestedFeatureIds = user.Feaures.Select(f => f.FeatureId).ToList();
                }
                   
                using (var db = new Db())
                {
                    db.Database.Log = m => Console.WriteLine(m);
                    //context.User.Where(u => userToSearch.features.Except(u.UserFeatures.Select(uf => uf.featuresId))).Any()==false).toListAsync();
                    var q = db.Users.Where(u => requestedFeatureIds.Except(u.Feaures.Select(uf => uf.FeatureId)).Any() == false);
    
                    var results = q.ToList();
    
                    var q2 = from u in db.Users
                             where requestedFeatureIds.Intersect(u.Feaures.Select(f => f.FeatureId)).Count() == requestedFeatureIds.Count
                             select u;
    
                    var results2 = q2.ToList();
                    
    
                }
    
    
                Console.WriteLine("Hit any key to exit");
                Console.ReadKey();
    
    
            }
        }
    }
