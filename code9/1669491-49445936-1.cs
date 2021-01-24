    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Dynamic;
    using System.IO;
    namespace ReadJson
    {
        class Program
        {
            static void Main(string[] args)
            {
                string filePath = "<full path to json file>";
                string json = File.ReadAllText(filePath);
                var expandoConverter = new ExpandoObjectConverter();
                dynamic obj = JsonConvert.DeserializeObject<ExpandoObject>(json, expandoConverter);
                //do more with your dynamic object here...
            }
        }
    }
