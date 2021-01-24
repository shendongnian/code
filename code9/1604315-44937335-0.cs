    using System;
    using System.Collections.Generic;
    using System.Data;
    
    namespace StronglyStypedSqlBulkCopy
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<Car> cars = GetSampleData();
                DataTable dataTable = ConvertToDataTable(cars);
    
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey(true);
            }
    
            public static List<Car> GetSampleData()
            {
                return new List<Car> {
                    new Car { Id = 1, Make = "Toyota", Model = "Tacoma", DateOfManufacture = DateTime.Now.AddDays(-1) },
                    new Car { Id = 2, Make = "Ford", Model = "Raptor", DateOfManufacture = DateTime.Now.AddDays(-2) },
                    new Car { Id = 3, Make = "Ram", Model = "1500", DateOfManufacture = DateTime.Now.AddDays(-3) }
                };
            }
    
            public static DataTable ConvertToDataTable<T>(IEnumerable<T> objects)
            {
                var properties = objects.GetType().GetGenericArguments()[0].GetProperties();
    
                var table = new DataTable();
    
                foreach (var property in properties)
                {
                    var columnName = property.Name; //may want to get from attribute also
                    //probably want to define an explicit mapping of .NET types to SQL types, and allow an attribute to specifically specify the SQL type
                    table.Columns.Add(columnName, property.PropertyType);
                }
    
                //probably want to cache the mapping from above in a real implementation
    
                foreach (var obj in objects)
                {
                    var row = table.NewRow();
    
                    foreach (var property in properties)
                    {
                        var columnName = property.Name; //may want to get from attribute also
                        var propertyValue = property.GetValue(obj);
                        row[columnName] = propertyValue;
                    }
    
                    table.Rows.Add(row);
                }
    
                return table;
            }
        }
    
        public class Car
        {
            public int Id { get; set; }
    
            public string Make { get; set; }
    
            public string Model { get; set; }
    
            public DateTime DateOfManufacture { get; set; }
        }
    }
