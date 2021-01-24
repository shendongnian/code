    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;
    using Newtonsoft.Json;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;
    using Newtonsoft.Json.Serialization;
    using System.Reflection;
    
    namespace EFCore2Test
    {
        public class Group
        {
            public int GroupId { get; set; }
            public string GroupName { get; set; }
            [JsonIgnore]
            public virtual ICollection<GroupMember> GroupMembers { get; } = new HashSet<GroupMember>();
    
            [NotMapped]
            public IList<User> Users => GroupMembers.Select(m => m.User).ToList();
        }
    
        public class GroupMember
        {
            public int GroupId { get; set; }
            public Group Group { get; set; }
            public int UserId { get; set; }
            public User User { get; set; }
        }
    
        public class User
        {
    
            public int UserId { get; set; }
            public string Email { get; set; }
    
            [JsonIgnore]
            public virtual ICollection<GroupMember> MemberOf { get; } = new HashSet<GroupMember>();
    
            [NotMapped]
            public IList<Group> Groups => MemberOf.Select(m => m.Group).ToList();
        }
    
        public class Db : DbContext
        {
    
    
            public DbSet<User> Users { get; set; }
            public DbSet<Group> Groups { get; set; }
    
            public DbSet<GroupMember> GroupMembers { get; set; }
    
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<GroupMember>()
                    .HasKey(t => new { t.UserId, t.GroupId });
    
                modelBuilder.Entity<GroupMember>()
                    .HasOne(pt => pt.User)
                    .WithMany(p => p.MemberOf)
                    .HasForeignKey(pt => pt.UserId);
    
                modelBuilder.Entity<GroupMember>()
                    .HasOne(pt => pt.Group)
                    .WithMany(t => t.GroupMembers)
                    .HasForeignKey(pt => pt.GroupId);
            }
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer("Server=(local);Database=Test;Trusted_Connection=True;MultipleActiveResultSets=true");
                base.OnConfiguring(optionsBuilder);
            }
        }
    
    
        class Program
        {
    
            public class DontSerialze<T> : DefaultContractResolver
            {
                
    
                protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
                {
        
                    JsonProperty property = base.CreateProperty(member, memberSerialization);
    
                    if (property.PropertyType == typeof(T))
                    {
                        property.ShouldSerialize = o => false;
                    }
    
                    return property;
                }
            }
            static void Main(string[] args)
            {
    
                using (var db = new Db())
                {
                    db.Database.EnsureDeleted();
                    db.Database.EnsureCreated();
    
                    var users = Enumerable.Range(1, 20).Select(i => new User() { Email = $"user{i}@wherever" }).ToList();
    
                    var groups = Enumerable.Range(1, 5).Select(i => new Group() { GroupName = $"group{i}" }).ToList();
    
                    var userGroups = (from u in users from g in groups select new GroupMember() { User = u, Group = g })
                                     .OrderBy(gm => (gm.Group.GroupName + gm.User.Email).GetHashCode())
                                     .Take(100)
                                     .ToList();
    
                    db.Users.AddRange(users);
                    db.Groups.AddRange(groups);
                    db.GroupMembers.AddRange(userGroups);
    
                    db.SaveChanges();
    
                    var ser = new JsonSerializer();
                    ser.Formatting = Formatting.Indented;
                    ser.ContractResolver = new DontSerialze<IList<User>>();
    
                    foreach (var u in users.Take(2))
                    {
                        ser.Serialize(Console.Out, u);
                        Console.WriteLine();
                    }
    
                }
                Console.WriteLine("Hit any key to exit");
                Console.ReadKey();
            }
        }
    }
