    class Program
    {
        static void Main(string[] args)
        {
            var jsonstring = "{\"text\":\"blah\",\"nodes\":[{\"text\":\"foo\", \"nodes\": []}, {\"text\":\"bar\", \"nodes\": []}, {\"text\":\"foo\", \"nodes\": []}]}";
            //This is the root node
            var firstLevelNodes = JsonConvert.DeserializeObject<Node>(jsonstring);
            //All the nodes in the root nodes node collection
            var secondLevelNodes = firstLevelNodes.nodes;
            //All of the nodes in the collections of the second level nodes
            var thirdLevelNodes = secondLevelNodes.SelectMany(sln => sln.nodes);
            Console.WriteLine("First Level Nodes: \n" + JsonConvert.SerializeObject(firstLevelNodes).PrettyPrint());
            Console.WriteLine();
            Console.WriteLine("Second Level Nodes: \n" + JsonConvert.SerializeObject(secondLevelNodes).PrettyPrint());
            Console.WriteLine();
            Console.WriteLine("Third Level Nodes: \n" + JsonConvert.SerializeObject(thirdLevelNodes).PrettyPrint());
            secondLevelNodes.First().nodes = new List<Node> { new Node { text = "new node" , nodes = new List<Node>() } };
            Console.WriteLine();
            Console.WriteLine("Third Level Nodes (with new node): \n" + JsonConvert.SerializeObject(thirdLevelNodes).PrettyPrint());
            Console.ReadLine();
        }
    }
    public static class JSONExtensions
    {
        public static string PrettyPrint(this string json)
        {
            dynamic parsedJson = JsonConvert.DeserializeObject(json);
            return JsonConvert.SerializeObject(parsedJson, Formatting.Indented);
        }
    }
    [Serializable]
    public class Node
    {
        public string text { get; set; }
        public IEnumerable<Node> nodes { get; set; }
    }
