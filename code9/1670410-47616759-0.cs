    using System;
    using Newtonsoft.Json.Linq;
    
    public class Test
    {
        static void Main()
        {
            string json = "{\"R27\":{\"DEVX\":0.1346224}}";
            var obj = JObject.Parse(json);
            double devX = (double) obj["R27"]["DEVX"];
            Console.WriteLine(devX);
        }
    }
