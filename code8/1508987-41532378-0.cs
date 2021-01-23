    using System.IO;
    using System.Web.Script.Serialization;
    
    namespace Deserialize
    {
        class Program
        {
            static void Main()
            {
                string jsonString = File.ReadAllText("dynamic.json");
    
                var serializer = new JavaScriptSerializer();
    
                dynamic data = serializer.Deserialize<dynamic>(jsonString);
    
                foreach (var item in data)
                {
                    foreach (var subitem in item)
                    {
                        System.Console.WriteLine("Key={0}, Value={1}", subitem.Key, subitem.Value);
                    }
    
                    System.Console.WriteLine();
                }
    
                System.Console.ReadKey();
            }
        }
    }
    
