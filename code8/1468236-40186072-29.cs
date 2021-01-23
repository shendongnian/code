    public class Program
    {
        public static void Main(string[] args)
        {
            int[] values = {10, 20, 30, 40, 50, 60, 70, 80, 90, 100};
            var treeBuilder = new TreeBuilder<int>(values[0]);
            foreach (int value in values.Skip(1))
            {
                treeBuilder.AddNode(value);
            }
            //here you can use treeBuilder Root property as an entry point to the tree
        }
    }
