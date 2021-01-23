    class Program
    {
        static void Main(string[] args)
        {
            var jsonstring = "{\"treeview\":[{\"text\":\"blah\",\"nodes\":[]},{\"text\":\"blah\",\"nodes\":[]},{\"text\":\"blah\",\"nodes\":[{\"text\":\"blah\",\"nodes\":[{\"text\":\"foo\",\"nodes\":[]}]}]},{\"text\":\"blah\",\"nodes\":[]},{\"text\":\"foo\",\"nodes\":[]}]}";
            //This is the root node
            var treeView = JsonConvert.DeserializeObject<TreeView>(jsonstring);
            //All the nodes in the root nodes node collection
            var firstLevelNodes = treeView.treeview;
            //All of the nodes in the collections of the first level nodes
            var secondLevelNodes = firstLevelNodes.SelectMany(fln => fln.nodes);
            //All of the nodes in the collections of the second level nodes
            var thirdLevelNodes = secondLevelNodes.SelectMany(sln => sln.nodes);
            Console.WriteLine("The TreeView: \n" + JsonConvert.SerializeObject(treeView, Formatting.Indented));
            thirdLevelNodes.First(sln => sln.text == "foo").nodes = new List<Node> { new Node { text = "new node", nodes = new List<Node>() } };
            Console.WriteLine();
            Console.WriteLine("The TreeView (with new node): \n" + JsonConvert.SerializeObject(treeView, Formatting.Indented));
            Console.ReadLine();
        }
    }
    [Serializable]
    public class Node
    {
        public string text { get; set; }
        public IEnumerable<Node> nodes { get; set; }
    }
    [Serializable]
    public class TreeView
    {
        public IEnumerable<Node> treeview { get; set; }
    }
