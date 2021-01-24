    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    
    namespace EfExperiment
    {
        class Program
        {
            public class Record
            {
                public int Id { get; set; }
                public DateTime Date { get; set; }
                public decimal Value { get; set; }
            }
    
            public class RecordsDbContext : DbContext
            {
                public DbSet<Record> Records { get; set; }
    
                public List<Record> RecordsByDateRange(DateTime fromDate, DateTime toDate)
                {
                    var fromDateParam = new SqlParameter("fromDate", fromDate);
                    var toDateParam = new SqlParameter("toDate", toDate);
    
                    return Records
                        .FromSql("EXECUTE dbo.RecordsByDateRange @fromDate, @toDate", fromDateParam, toDateParam)
                        .ToList();
                }
    
                protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
                {
                    optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=RecordsDb;Trusted_Connection=True;");
                }
            }
    
            static void Main(string[] args)
            {
                using (var dbc = new RecordsDbContext())
                {
                    var records = dbc.RecordsByDateRange(DateTime.Now.AddMonths(-1), DateTime.Now);
                    Console.WriteLine($"{records.Count} records loaded");
    
                    foreach (var record in records)
                    {
                        Console.WriteLine($"[{record.Id}] [{record.Date}] {record.Value}");
                    }
                }
    
                Console.WriteLine("Press <enter>");
                Console.ReadLine();
            }
        }
    }
