    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Linq;
    namespace ClientSelectsProperties
    {
        public class OriginalType
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
        }
        class Program
        {
            // this simulates your original query result - it has all properties
            private static List<OriginalType> queryResult = new List<OriginalType> {
                new OriginalType { Id = 1, Name = "one", Description = "one description" },
                new OriginalType { Id = 1, Name = "two", Description = "two description" }
            };
            // "hardcoded" property value readers, go crazy here and construct them dynamically if you want (reflection, code generation...)
            private static Dictionary<string, Func<OriginalType, object>> propertyReaders = new Dictionary<string, Func<OriginalType, object>> {
                { "Id", t => t.Id },
                { "Name", t => t.Name },
                { "Description", t => t.Description }
            };
            static void Main(string[] args)
            {
                // your client only wants Id and Name
                var result = GetWhatClientWants(new List<string> { "Id", "Name" });
            }
            private static List<dynamic> GetWhatClientWants(List<string> propertyNames)
            {
                // make sure your queryResult is in-memory collection here. Body of this select cannot be executed in the database
                return queryResult.Select(t =>
                {
                    var expando = new ExpandoObject();
                    var expandoDict = expando as IDictionary<string, object>;
                    foreach (var propertyName in propertyNames)
                    {
                        expandoDict.Add(propertyName, propertyReaders[propertyName](t));
                    }
                    return (dynamic)expando;
                }).ToList();
            }
        }
    }
