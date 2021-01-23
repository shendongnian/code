    class Program
        {
            static void Main(string[] args)
            {
                var jsonstring = "{\"text\":\"blah\",\"nodes\":[{\"text\":\"foo\", \"nodes\": []}, {\"text\":\"bar\", \"nodes\": []}, {\"text\":\"foo\", \"nodes\": []}]}";
    
                var nodes = JsonConvert.DeserializeObject<Node>(jsonstring);
    
                var foonodes = nodes.nodes.Where(n => n.text == "foo");
    
                foonodes.First().nodes = new List<Node> { new Node { text = "new node" } };
    
                Console.WriteLine(JsonConvert.SerializeObject(nodes));
    
                Console.ReadLine();
    
            }
        }
    
        [Serializable]
        public class Node
        {
            public string text { get; set; }
            public IEnumerable<Node> nodes { get; set; }
        }
    }
