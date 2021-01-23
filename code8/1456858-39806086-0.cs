    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;
    
    namespace StackOverflowTests {
      class Program {
        static void Main(string[] args) {
          var assembly = Assembly.GetExecutingAssembly();
          var resource = "StackOverflowTests.StatusCustomer.json";
    
          var deserializedResource = GetEmbeddedResource<List<CustomerStatus>>(assembly, resource);
    
          Console.WriteLine(JsonConvert.SerializeObject(deserializedResource));
          Console.ReadKey();
        }
    
        private static T GetEmbeddedResource<T>(Assembly assembly, string resource) {
          using (Stream manifestStream = assembly.GetManifestResourceStream(resource))
          using (StreamReader reader = new StreamReader(manifestStream)) {
            string result = reader.ReadToEnd();
            return JsonConvert.DeserializeObject<T>(result);
          }
        }
    
        public class CustomerStatus {
          public int Status { get; set; }
          public string CustomerId { get; set; }
        }
      }
    }
