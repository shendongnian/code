    using Newtonsoft.Json;
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.IO;
    using System.Linq;
    
    namespace ConsoleApp6
    {
    
        public class Company
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public DateTime dtEstablished { get; set; }
    
            [NotMapped]
            public Car[] CarsManufactured
            {
                get
                {
                    var ser = new JsonSerializer();
                    var jr = new JsonTextReader(new StringReader(CarsManufacturedJSON));
    
                    return ser.Deserialize<Car[]>(jr);
                }
                set
                {
                    var ser = new JsonSerializer();
                    var sw = new StringWriter();
                    ser.Serialize(sw,value);
                    CarsManufacturedJSON = sw.ToString();
                }
            }
    
            [Column("CarsManufactured")]
            public string CarsManufacturedJSON { get; set; }
    
    
        }
        
        public class Car
        {
       
            public string Name { get; set; }
            public string Model { get; set; }
            public DateTime MfgDate { get; set; }
            public string Type { get; set; }
        }
        class Db: DbContext
        {
            public DbSet<Company> Companies { get; set; }
            
        }
        class Program
        {
            
            static void Main(string[] args)
            {
                Database.SetInitializer(new DropCreateDatabaseAlways<Db>());
    
                using (var db = new Db())
                {
                    db.Database.Log = m => Console.WriteLine(m);
    
                    var company = db.Companies.Create();
                    company.Name = "Acme";
                    company.dtEstablished = new DateTime(2000, 2, 2);
    
                    var cars = new Car[5];
                    for (int i = 0; i<cars.Length; i++)
                    {
                        var c = new Car()
                        {
                            MfgDate = new DateTime(2010 + i, 1, 1),
                            Model = $"Model{i}",
                            Name = $"ModelName{i}",
                            Type = $"Type{i}"
    
                        };
                        cars[i] = c;
                    }
                    
                    company.CarsManufactured = cars;
    
                    db.Companies.Add(company);
                    db.SaveChanges();
                    
                }
                using (var db = new Db())
                {
                    var company = db.Companies.First();
                    Console.WriteLine(company.CarsManufacturedJSON);
    
                }
                Console.ReadKey();
    
            }
        }
    }
