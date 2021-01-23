      class Program
      {
        static void Main(string[] args)
        {
          var nodeData = new [] { 10, 20, 30, 40, 50, 60, 70, 80,90,100 };
          var tree1 = new Tree<int>(nodeData);
    
          tree1.Write();
          
          Console.ReadKey();
        }
      }
