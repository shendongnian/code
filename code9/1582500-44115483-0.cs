    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApp8
    {
    
        public partial class Table1
        {
            public int Id { get; set; }
            public string Name { get; set; }
    
            public virtual Table3 Table3 { get; set; }
        }
    
        public partial class Table2
        {
            public int Id { get; set; }
            public string Name { get; set; }
    
            public virtual Table3 Table3 { get; set; }
        }
    
        public partial class Table3
        {
            public Table3() { }
            public Table3(Table1 s) { this.Table1 = s; this.Table2 = null; }
            public Table3(Table2 t) { this.Table2 = t; this.Table1 = null; }
    
            public int Id { get; set; }
            public string Name { get; set; }
    
            public virtual Table1 Table1 { get; set; }
            public virtual Table2 Table2 { get; set; }
        }
    
        class Db : DbContext
        {
            public DbSet<Table1> Table1 { get; set; }
            public DbSet<Table2> Table2 { get; set; }
            public DbSet<Table3> Table3 { get; set; }
    
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Table1>()
                            .HasOptional(t => t.Table3)
                            .WithOptionalPrincipal(t1 => t1.Table1);
    
                modelBuilder.Entity<Table2>()
                            .HasOptional(t => t.Table3)
                            .WithOptionalDependent(t => t.Table2);
    
                modelBuilder.Entity<Table1>()
                            .Property(t => t.Id)
                            .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
    
                modelBuilder.Entity<Table2>()
                .Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
    
                modelBuilder.Entity<Table3>()
                .Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
    
    
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                using (var db = new Db())
                {
    
    
                    Table1 T1 = new Table1()
                    {
                        Name = "Foo"
                    };
    
                    db.Table1.Add(T1);
                    db.SaveChanges();   // works sucessfully 
                                        // Data in inserted
                    Table3 t3 = new Table3()
                    {
                        Name = "Bar",
                        Table1 = T1,
                        Table2 = null
                    };
    
                    db.Table3.Add(t3);
                    db.SaveChanges(); 
    
                    var t2 = new Table2()
                    {
                        Name = "Baz",
                        Table3 = t3
                    };
                    db.Table2.Add(t2);
                    db.SaveChanges();
                }
            }
        }
    }
