    using System.Web;
    using Newtonsoft.Json.Linq;
    namespace MyTestProjectConsole
    {
        public class Test1Json
        {
            public void ConvertJson()
           {
                string clientID = "aa";
                string clientSecret = "bb";
                var stringObject = "{ clientID:" + "'" + clientID + "', clientSecret:" + "'" + clientSecret + "'}";
                var json = JObject.Parse(stringObject);
                Console.WriteLine(json);
            }
            public static void Main()
            {
                Test1Json obj = new Test1Json();
                obj.ConvertJson();
                Console.ReadKey();
            }
        }
    }
 
