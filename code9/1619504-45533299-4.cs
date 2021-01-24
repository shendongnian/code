    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    
    namespace efCoreTest
    {
        [Table("SomeEntity")]
        class SomeEntity
        {
            
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
    
            public DateTime CreatedOn { get; set; }
            public int A { get; set; }
            public int B { get; set; }
            public int C { get; set; }
            public int D { get; set; }
    
            virtual public Address Address { get; set; }
            public int AddressId { get; set; }
    
        }
    
        [Table("Address")]
        class Address
        {
            [DatabaseGenerated(DatabaseGeneratedOption.None)]
            public int Id { get; set; }
            public string Line1 { get; set; }
            public string Line2 { get; set; }
            public string Line3 { get; set; }
    
        }
        class Db : DbContext
        {
            public DbSet<SomeEntity> SomeEntities { get; set; }
    
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=efCoreTest;Integrated Security=true");
            }
    
        }
        class Program
        {
            static void Main(string[] args)
            {
                using (var db = new Db())
                {
                    db.Database.EnsureDeleted();
                    db.Database.EnsureCreated();
    
                    db.Database.ExecuteSqlCommand("alter database EfCoreTest set recovery simple;");
    
                    var LoadAddressesSql = @"
    
    with N as
    (
       select top (10) cast(row_number() over (order by (select null)) as int) i
       from sys.objects o, sys.columns c, sys.columns c2
    )
    insert into Address(Id, Line1, Line2, Line3)
    select i Id, 'AddressLine1' Line1,'AddressLine2' Line2,'AddressLine3' Line3
    from N;
    ";
    
                    var LoadEntitySql = @"
    
    with N as
    (
       select top (1000000) cast(row_number() over (order by (select null)) as int) i
       from sys.objects o, sys.columns c, sys.columns c2
    )
    insert into SomeEntity (Name, Description, CreatedOn, A,B,C,D, AddressId)
    select  concat('EntityName',i) Name,
            concat('Entity Description which is really rather long for Entity whose ID happens to be ',i) Description,
            getdate() CreatedOn,
            i A, i B, i C, i D, 1+i%10 AddressId
    from N
            
    ";
                    Console.WriteLine("Generating Data ...");
                    db.Database.ExecuteSqlCommand(LoadAddressesSql);
                    Console.WriteLine("Loaded Addresses");
    
                    for (int i = 0; i < 10; i++)
                    {
                        var rows = db.Database.ExecuteSqlCommand(LoadEntitySql);
                        Console.WriteLine($"Loaded Entity Batch {rows} rows");
                    }
    
                 
                    Console.WriteLine("Finished Generating Data");
    
                    var results = db.SomeEntities.AsNoTracking().Include(e => e.Address).AsEnumerable();
    
                    int batchSize = 10 * 1000;
                    int ix = 0;
                    foreach (var r in results)
                    {
                        ix++;
    
                        if (ix % batchSize == 0)
                        {
                            Console.WriteLine($"Read Entity {ix} with name {r.Name}.  Current Memory: {GC.GetTotalMemory(false) / 1024}kb GC's Gen0:{GC.CollectionCount(0)} Gen1:{GC.CollectionCount(1)} Gen2:{GC.CollectionCount(2)}");
                            
                        }
    
                    }
    
                    Console.WriteLine($"Done.  Current Memory: {GC.GetTotalMemory(false)/1024}kb");
    
                    Console.ReadKey();
                }
            }
        }
    }
