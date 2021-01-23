    class Program
    {
    
        static void Do(ref Node node)
        {
            node.occupant = 1;
        }
        static void Main()
        {
            Node[] nodes = new Node[10];
            nodes[5].occupant = 2;
    
            Do(ref nodes[5]);
            Console.WriteLine(nodes[5].occupant);
    
            Console.ReadLine();
    
        }
    }
