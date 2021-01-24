    using Newtonsoft.Json;
    using System;
    
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var str = "{ \"ResultTwo\":{ \"Value1\":2,\"Value2\":3,\"Type\":\"SimpleSubtract\",\"Result\":-1}}";
    
                dynamic des = JsonConvert.DeserializeObject(str);
                var val = (int)des.ResultTwo.Value1;
                Console.WriteLine(val);
            }
        }
    }
