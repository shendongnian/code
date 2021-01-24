    using System;
    using Newtonsoft.Json.Linq;
    
    namespace JSON_Comparison_Test
    {
        class Program
        {
            static void Main(string[] args)
            {
    
                String jsonString1 = "{\"key1\":\"ABC\",\"key2\":\"DEF\"}";
                String jsonString2 = "{ \"key2\":\"DEF\" , \r\n \t  \"key1\" : \"\u0041BC\" }";
    
                var obj1 = JToken.Parse(jsonString1);
                var obj2 = JToken.Parse(jsonString2);
    
                var comparer = new JTokenEqualityComparer();
                var hashCode1 = comparer.GetHashCode(obj1);
                var hashCode2 = comparer.GetHashCode(obj2);
    
                Console.WriteLine(hashCode1.ToString()); // -323033486
                Console.WriteLine(hashCode2.ToString()); // -323033486
    
                Console.WriteLine(comparer.Equals(obj1, obj2)); // True
            }
        }
    }
    
