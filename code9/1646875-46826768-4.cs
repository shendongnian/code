    namespace MySimpleParser
    {
        class Program
        {
            public static void Main(string[] args)
            {
                string s = GetInput();
                try
                {
                    Node root = Parser.Deserialize(s);
                    PrintBranch(root, 1);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.GetType().Name}: {ex.Message}");
                }
    
                Console.ReadLine();
            }
    
            internal static string GetInput()
            {
                return @"id i { 
                            any data; any [con=tent]
                            id j {
                                any inner data
                            }
                            id k {
                                bla
                                id m {
                                    any
                                }
                                thing 
                            }
                        }";
            }
    
            internal static void PrintNode(Node n, int depth)
            {
                string indent = new string('-', 3 * depth);
                Console.WriteLine($"{indent} Name: {n.Name}");
                Console.WriteLine($"{indent} Contents: {n.Contents}");
                Console.WriteLine($"{indent} Child Nodes: {n.InnerNodes.Count}");
            }
    
            internal static void PrintBranch(Node root, int depth)
            {
                PrintNode(root, depth);
                foreach (Node child in root.InnerNodes) PrintBranch(child, depth + 1);
            }
        }
    }
