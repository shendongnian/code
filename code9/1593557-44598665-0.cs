    using MongoDB.Bson.Serialization.Conventions;
    using MongoDB.Driver;
    using System;
    using System.Linq;
    
    namespace ConsoleApp1
    {
        public class cls_Patient
        {
            public string MRN;
            public string Family_Name;
            public string First_Name;
            public string Father_Name;
            public string Spouse_Name;
            public string Address;
        }
    
        public class Program
        {
            static void Main(string[] args)
            {
                ConventionPack p = new ConventionPack();
                p.Add(new IgnoreExtraElementsConvention(true));
                ConventionRegistry.Register("Ignore extra elements", p, _ => true);
    
                var collection = new MongoClient().GetDatabase("test").GetCollection<cls_Patient>("Person");
                
                var names = collection.AsQueryable().
                  Where(patient => patient.MRN == "00038063" && patient.Father_Name != "")
                    .OrderBy(patient => patient.First_Name)
                    .ThenBy(patient => patient.Family_Name).ToList();
                Console.ReadLine();
            }
        }
    }
