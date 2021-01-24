    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    
    namespace ConsoleApp6
    {
    
        public class Application
        {
            [Key]
            public string Code { get; set; }
        }
    
        public class Table1
        {
            [Key]
            [Column(Order = 0)]
            public string Table1Code { get; set; }
    
            [Key, ForeignKey("ApplicationObject")]
            [Column(Order = 1)]
            public string Application { get; set; }
            public virtual Application ApplicationObject { get; set; }
        }
    
        public class Table2
        {
            [Key]
            [Column(Order = 0)]
            public string Table2Code { get; set; }
    
            [Key, ForeignKey("ApplicationObject")]
            [Column(Order = 1)]
            public string Application { get; set; }
            public virtual Application ApplicationObject { get; set; }
        }
    
        public class Table3
        {
            [Key]
            [Column(Order = 0)]
            public string Table1Code { get; set; }
    
            [Key]
            [Column(Order = 1)]
            public string Table2Code { get; set; }
    
            [Key]
            [Column(Order = 2)]
            public string ApplicationCode { get; set; }
    
            [ForeignKey("Table1Code,ApplicationCode")]
            public virtual Table1 Table1Object { get; set; }
    
            [ForeignKey("Table2Code,ApplicationCode")]
            public virtual Table2 Table2Object { get; set; }
    
    
    
        }
        class Db: DbContext
        {
    
    
            public DbSet<Table1> Table1 { get; set; }
            public DbSet<Table2> Table2 { get; set; }
            public DbSet<Table3> Table3 { get; set; }
    
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Conventions.Remove<System.Data.Entity.ModelConfiguration.Conventions.OneToManyCascadeDeleteConvention>();
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
                    
                    
                }
      
                Console.ReadKey();
    
            }
        }
    }
