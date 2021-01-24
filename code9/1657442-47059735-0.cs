    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    
    namespace Ef6Test
    {
    
    
        public class Foo
        {
            public int Id { get; set; }
    
            [Column("Nb_delays_90+_ever")]
            public int? Nb_delays_90__ever { get; set; }
        }
    
        public class Db : DbContext
        {
            public DbSet<Foo> Foos { get; set; }
    
    
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
                    db.Database.Initialize(true);
    
                    var f = new Foo();
                    f.Nb_delays_90__ever = 2;
    
                    db.Foos.Add(f);
                    db.SaveChanges();
    
                }
    
                Console.WriteLine("Hit any key to exit");
                Console.ReadKey();
            }
        }
    }
