    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ef62test
    {
        class Program
        {
    
            public partial class Owner
            {
                public string Id { get; set; }
                public string OwnerName { get; set; }
                public virtual ICollection<Widget> Widgets { get; } = new HashSet<Widget>();
    
            }
    
            public partial class Widget
            {
                public int id { get; set; }
                public string OwnerId { get; set; }
                public string WidgetName { get; set; }
                public string WidgetType { get; set; }
                public virtual Owner Owners { get; set; }
            }
    
            public partial class Model1 : DbContext
            {
         
                public virtual DbSet<Owner> Owners { get; set; }
                public virtual DbSet<Widget> Widgets { get; set; }
                protected override void OnModelCreating(DbModelBuilder modelBuilder)
                {
                    modelBuilder.Entity<Owner>()
                        .HasMany(e => e.Widgets)
                        .WithRequired(e => e.Owners)
                        .HasForeignKey(e => e.OwnerId)
                        .WillCascadeOnDelete(false);
                }
            }
            static void Main(string[] args)
            {
                Database.SetInitializer(new DropCreateDatabaseAlways<Model1>());
    
                string ownerId = "owner1";
                using (var db = new Model1())
                {
                    db.Database.Log = s => Console.WriteLine(s);
                    var o = new Owner() { Id = ownerId };
    
                    db.Owners.Add(o);
    
                    for (int i = 0; i < 10; i++)
                    {
                        o.Widgets.Add(new Widget());
                    }
                    db.SaveChanges();
                    ownerId = o.Id;
    
                    db.Database.ExecuteSqlCommand("update widgets set ownerId = UPPER(ownerId);");
                }
    
                using (var db = new Model1())
                {
                    db.Database.Log = s => Console.WriteLine(s);
                    db.Configuration.LazyLoadingEnabled = false;
    
                    var owner = db.Owners.Include(o => o.Widgets).Where(o => o.Id == ownerId).First();
    
                    Console.WriteLine(owner.Widgets.Count());
                }
    
                Console.WriteLine("Hit any key to exit.");
                Console.ReadKey();
            }
        }
    }
