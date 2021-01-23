    using Newtonsoft.Json.Linq;
    public class Program
    {
        public static void Main(string[] args)
        {
            string json1 = @"
            {
              ""foo"": { ""bar"": 42, ""baz"": [ ""a"", ""b"", ""c"" ] }
            }";
            DeserializeAndDump(json1, "example 1");
            string json2 = @"
            [
              { ""foo"": ""bar"", ""baz"": [ 1, 2, 3 ] },
              { ""foo"": ""baz"", ""bar"": [ 4, 5, 6 ] }
            ]";
            DeserializeAndDump(json2, "example 2");
        }
        public static void DeserializeAndDump(string json, string label)
        {
            Console.WriteLine("---- " + label + " ----");
            JToken token = JToken.Parse(json);
            DumpJToken(token);
            Console.WriteLine();
        }
        public static void DumpJToken(JToken token, string indent = "")
        {
            if (token.Type == JTokenType.Object)
            {
                Console.WriteLine(indent + "begin object");
                foreach (JProperty prop in token.Children<JProperty>())
                {
                    Console.WriteLine(indent + "  " + prop.Name + ":");
                    DumpJToken(prop.Value, indent + "    ");
                }
                Console.WriteLine(indent + "end object");
            }
            else if (token.Type == JTokenType.Array)
            {
                Console.WriteLine(indent + "begin array");
                foreach (JToken child in token.Children())
                {
                    DumpJToken(child, indent + "  ");
                }
                Console.WriteLine(indent + "end array");
            }
            else
            {
                Console.WriteLine(indent + token.ToString() + " (" + token.Type.ToString() + ")");
            }
        }
    }
