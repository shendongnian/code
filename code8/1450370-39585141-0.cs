    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                string json = @"....your JSON ....";
    
                var node = JToken.Parse(json);
    
                RecursiveDescent(node, n =>
                {
                    JToken url = n["thumbnailUrl"];
                    if (url != null && url.Type == JTokenType.String)
                    {
                        var nodeWeWant = url?.Parent?.Parent?.Parent?.Parent;
                        
                        Console.WriteLine(nodeWeWant.ToString());
                    }
                });
            }
    
            static void RecursiveDescent(JToken node, Action<JObject> action)
            {
                if (node.Type == JTokenType.Object)
                {
                    action((JObject)node);
                    foreach (JProperty child in node.Children<JProperty>())
                        RecursiveDescent(child.Value, action);
                }
                else if (node.Type == JTokenType.Array)
                {
                    foreach (JToken child in node.Children())
                        RecursiveDescent(child, action);
                }
            }
        }
    }
