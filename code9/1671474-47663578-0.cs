    using System;
    using System.Collections.Generic;
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
            public int Id { get; set; }
    
            public Address Address { get; set; }
            public int AddressId { get; set; }
            public Member  Member{ get; set; }
            public int MemberId{ get; set; }
        }
        class Db : DbContext
        {
            public DbSet<Address> Address { get; set; }
            public DbSet<Member> Memeber{ get; set; }
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
    
                    var a = new Address();
                    var m = new Member();
    
                    for (int i = 0; i < 10; i++)
                    {
                        var ma = new MemberAddress();
                        ma.Address = a;
                        ma.Member = m;
                        db.MemberAddresses.Add(ma);
                    }
    
                    db.Address.Add(a);
                    db.Memeber.Add(m);
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
    
                }
    
    
                
                Console.WriteLine("Hit any key to exit");
                Console.ReadKey();
            }
        }
    }
