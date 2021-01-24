    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Linq;
    
    namespace Ef6Test
    {
    
        public class Address
        {
            public int Id { get; set; }
            public virtual ICollection<MemberAddress> MemberAddresses { get; } = new HashSet<MemberAddress>();
        }
        public class Member
        {
            public int Id { get; set; }
            public virtual ICollection<MemberAddress> MemberAddresses { get; } = new HashSet<MemberAddress>();
        }
        public class MemberAddress
    
        {
            public Address Address { get; set; }
            [Key( ), Column(Order =0)]
            public int AddressId { get; set; }
            public Member  Member{ get; set; }
    
            [Key(), Column(Order = 1)]
            public int MemberId{ get; set; }
    
        }
        class Db : DbContext
        {
            public DbSet<Address> Address { get; set; }
            public DbSet<Member> Member{ get; set; }
            public DbSet<MemberAddress> MemberAddresses { get; set; }
    
    
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
                    db.Database.Initialize(true);
    
                    
                    var m = new Member();
    
                    for (int i = 0; i < 10; i++)
                    {
                        var a = new Address();
                        var ma = new MemberAddress();
                        ma.Address = a;
                        ma.Member = m;
                        db.Address.Add(a);
                        db.MemberAddresses.Add(ma);
                    }
    
                    
                    db.Member.Add(m);
                    db.SaveChanges();
    
                }
    
                Console.WriteLine("Enumerating Include Query");
                using (var db = new Db())
                {
    
                    db.Database.Log = m => Console.WriteLine(m);
    
                    var list = db.MemberAddresses.Include(rp => rp.Address).Where(rp => rp.MemberId < 10).ToList();
    
                    foreach (var e in db.ChangeTracker.Entries())
                    {
                        Console.WriteLine(e.Entity.GetType().Name);
                    }
                    var a = db.ChangeTracker.Entries<MemberAddress>().First();
                    Console.WriteLine($"Address IsLoaded: {a.Reference<Address>("Address").IsLoaded}");
    
                    Console.WriteLine($"Member Local {db.Member.Local.Count} items");
                    foreach (var member in db.Member.Local)
                    {
                        Console.WriteLine($"Member {member.Id}");
                    }
                    Console.WriteLine($"MemberAddress Local {db.MemberAddresses.Local.Count} items");
                    foreach (var ma in db.MemberAddresses.Local)
                    {
                        Console.WriteLine($"MemberAddress {ma.MemberId},{ma.AddressId}");
                    }
                    Console.WriteLine($"Address Local {db.Address.Local.Count} items");
                    foreach (var ad in db.Address.Local)
                    {
                        Console.WriteLine($"Address {ad.Id}");
                    }
    
    
                }
    
                Console.WriteLine("Using Load()");
                using (var db = new Db())
                {
    
                    db.Database.Log = m => Console.WriteLine(m);
    
                    db.MemberAddresses.Include(rp => rp.Address).Where(rp => rp.MemberId < 10).Load();
    
                    foreach (var e in db.ChangeTracker.Entries())
                    {
                        Console.WriteLine(e.Entity.GetType().Name);
                    }
                    var a = db.ChangeTracker.Entries<MemberAddress>().First();
                    Console.WriteLine($"Address IsLoaded: {a.Reference<Address>("Address").IsLoaded}");
    
                    Console.WriteLine($"Member Local {db.Member.Local.Count} items");
                    foreach (var member in db.Member.Local)
                    {
                        Console.WriteLine($"Member {member.Id}");
                    }
                    Console.WriteLine($"MemberAddress Local {db.MemberAddresses.Local.Count} items");
                    foreach (var ma in db.MemberAddresses.Local)
                    {
                        Console.WriteLine($"MemberAddress {ma.MemberId},{ma.AddressId}");
                    }
                    Console.WriteLine($"Address Local {db.Address.Local.Count} items");
                    foreach (var ad in db.Address.Local)
                    {
                        Console.WriteLine($"Address {ad.Id}");
                    }
    
                }
    
    
                
                Console.WriteLine("Hit any key to exit");
                Console.ReadKey();
            }
        }
    }
