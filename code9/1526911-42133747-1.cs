      class Program
    {
        static void Main(string[] args)
        {
            List<Tree> treeItems = SomeMethod(); 
            Console.WriteLine("BEFORE");            
            Write(treeItems.First(), 0);
            Do(treeItems.First());
            Console.WriteLine();
            Console.WriteLine("AFTER");            
            Write(treeItems.First(), 0);
            Console.ReadKey();
        }
        private static void Write(Tree t, int currentLevel)
        {
            string space = " ".PadLeft(currentLevel);            
            Console.WriteLine($"{space}{t.Id} : {t.text} : {t.nodes?.Count.ToString() ?? "NULL"}");
            if (t.nodes == null)
                return;
            foreach (Tree tree in t.nodes)
            {                                              
                Write(tree, currentLevel + 1);
            }
        }
        private static void Do(Tree t)
        {
            foreach (Tree tree in t.nodes)
            {
                Do(tree);
            }
            if (t.nodes.Count == 0)
                t.nodes = null;                          
        }
        private static List<Tree> SomeMethod()
        {
            List<Tree> root = new List<Tree>()
            {
                new Tree() {Id = 1, text = "Root", ParentId = -1, nodes = new List<Tree>()}
            };
            root[0].nodes.Add(new Tree { Id = 4, text = "Level2A", ParentId = 2, nodes = new List<Tree>() });
            root[0].nodes.Add(new Tree { Id = 5, text = "Level2B", ParentId = 2, nodes = new List<Tree>()});
            root[0].nodes[1].nodes.Add(new Tree { Id = 6, text = "Level3A", ParentId = 5, nodes = new List<Tree>() });
            root[0].nodes[1].nodes.Add(new Tree { Id = 7, text = "Level3B", ParentId = 5, nodes = new List<Tree>() });
            root[0].nodes[1].nodes.Add(new Tree { Id = 8, text = "Level3C", ParentId = 5, nodes = new List<Tree>() });
                 
            root[0].nodes[1].nodes[1].nodes.Add(new Tree { Id = 9, text = "Level4A", ParentId = 7, nodes = new List<Tree>() });
            root[0].nodes[1].nodes[1].nodes[0].nodes.Add(new Tree { Id = 10, text = "Level5A", ParentId = 9, nodes = new List<Tree>() });
            root[0].nodes[1].nodes[1].nodes[0].nodes.Add(new Tree { Id = 11, text = "Level5b", ParentId = 9, nodes = new List<Tree>() });
            return root;
        }
        public class Tree
        {
            public int Id { get; set; }
            public string text { get; set; }
            public int ParentId { get; set; }
            public List<Tree> nodes { get; set; }
        }
    }
