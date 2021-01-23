    public class Program
    {
        public static void Main(string[] args)
        {
            int[] values = {10, 20, 30, 40, 50, 60, 70, 80, 90, 100};
            TreeBuilder treeBuilder = new TreeBuilder();
            Node root = new Node(values[0]);
            treeBuilder.AddNode(root);
            foreach (int value in values.Skip(1))
            {
                treeBuilder.AddNode(new Node(value));
            }
            //here you can use root variable as an entry point to the all tree
        }
    }
