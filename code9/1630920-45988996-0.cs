    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    
    namespace Ef6Test
    {
    
        public class Role
        {
            public long RoleId { get; set; }
        }
        public class RoutingPath
        {
            public int RoutingPathId { get; set; }
        }
        public class Environment
        {
            public string EnvironmentId { get; set; }
        }
        public class RoleInstance
        {
            [Key, Column(Order = 1)]
            public long RoleId { get; set; }
            [Key, Column(Order = 2)]
            public string EnvirCode { get; set; }
    
            public int PathId { get; set; }
    
            public char Published { get; set; }
    
            [ForeignKey("RoleId")]
            public virtual Role Role { get; set; }
            [ForeignKey("PathId")]
            public virtual RoutingPath RoutingPath { get; set; }
            [ForeignKey("EnvirCode")]
            public virtual Environment Environment { get; set; }
    
            public ICollection<ActiveDirectoryGroup> ActiveDirectoryGroups { get; } = new HashSet<ActiveDirectoryGroup>();
        }
    
        public class ActiveDirectoryGroup
        {
            [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
            public int Id { get; set; }
    
            public long RoleId { get; set; }
    
            public string EnvirCode { get; set; }
            public string GroupName { get; set; }
            public string GroupGuid { get; set; }
            public char AuditGroup { get; set; }
    
            [ForeignKey("RoleId,EnvirCode")]
            public virtual RoleInstance RoleInstance { get; set; }
        }
    
        class Db : DbContext
        {
    
            public DbSet<ActiveDirectoryGroup> ActiveDirectoryGroups { get; set; }
            public DbSet<RoleInstance> RoleInstances { get; set; }
    
    
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
                    db.Database.Initialize(false);
    
                    db.Database.Log = msg => Console.WriteLine(msg);
    
                    RoleInstance ri = new RoleInstance
                    {
                        Role = new Role() { RoleId = 1},
                        Environment = new Environment() {  EnvironmentId = "ENVIR" },
                        RoutingPath = new RoutingPath() {  RoutingPathId = 5 },
                        Published = 'Y'
                    };
    
                    ri.ActiveDirectoryGroups.Add(new ActiveDirectoryGroup()
                    {
                        GroupName = "GROUP NAME",
                        AuditGroup = 'Y'
                    });
    
                    db.RoleInstances.Add(ri);
                    db.SaveChanges();
    
                   
                }
    
                using (var db = new Db())
                {
                    foreach (var g in db.ActiveDirectoryGroups)
                    {
                        Console.WriteLine($"RoleId: {g.RoleId}, EnvirCode: { g.EnvirCode}");
                    }
                }
    
                Console.ReadKey();
            }
        }
    }
