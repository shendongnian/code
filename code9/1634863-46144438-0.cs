    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Common;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Transactions;
    
    namespace ConsoleApp8
    {
    
        public class A
        {
            public int AID { get; set; }
            public string Name { get; set; }
        }
    
        public class B
        {
    
            public int BId { get; set; }
            public string Name { get; set; }
        }
        class DbA : DbContext
        {
            public DbA(): base()
            {
    
            }
            public DbA(DbConnection con) : base(con,false)
            {
    
            }
            public DbSet<A> A { get; set; }
    
    
        }
        class DbB : DbContext
        {
            public DbB() : base()
            {
    
            }
            public DbB(DbConnection con) : base(con, false)
            {
    
            }
            public DbSet<B> B { get; set; }
    
    
        }
    
    
    
        class Program
        {      
    
            static void Main(string[] args)
            {
    
                Database.SetInitializer(new CreateDatabaseIfNotExists<DbA>());
                Database.SetInitializer(new CreateDatabaseIfNotExists<DbB>());
                string DatabaseNameA, DatabaseNameB;
                using (var db = new DbA())
                {
                    db.Database.Initialize(false);
                    DatabaseNameA = db.Database.Connection.Database;
                }
              
                using (var db = new DbB())
                {
                    db.Database.Initialize(false);
                    DatabaseNameB = db.Database.Connection.Database;
                }
    
                var opts = new TransactionOptions() { IsolationLevel = IsolationLevel.ReadCommitted };
    
                using (var dbA = new DbA())
                using (var tran = new TransactionScope(TransactionScopeOption.Required, opts))
                {
                  
    
                    var a = dbA.A.Create();
                    a.Name = "someA";
                    dbA.A.Add(a);
                    dbA.SaveChanges();
    
                    dbA.Database.ExecuteSqlCommand($"use [{DatabaseNameB}]");
                    using (var dbB = new DbB(dbA.Database.Connection))
                    {
                       
                        var b = dbB.B.Create();
                        b.Name = "someB";
                        dbB.B.Add(b);
                        dbB.SaveChanges();
    
                    }
    
                    tran.Dispose();
    
                }
    
    
    
                using (var dbA = new DbA())
                {
                    dbA.Database.Connection.Open(); //lock the connection open if not using a transaction
                    Console.WriteLine($"Count of A: {dbA.A.Count()}");
    
                    dbA.Database.ExecuteSqlCommand($"use [{DatabaseNameB}]");
                    using (var dbB = new DbB(dbA.Database.Connection))
                    {
                        Console.WriteLine($"Count of B: {dbB.B.Count()}");
    
                    }
    
                  
    
                }
    
                Console.WriteLine("Hit any key to exit");
                Console.ReadKey();
    
    
    
    
    
    
            }
        }
    }
