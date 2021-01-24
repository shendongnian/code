     static int sizeOfTab;
     static int[] tab;
    
    
    static void Main(string[] args)
    {
            CollectSizeOfTab(args);
                    
            CreateTab();
                
            InsertValuesToTab(tab);
                
            Sort(tab);
                        
    }
    static void CollectSizeOfTab(string[] args)
    {
        do
        {
          Console.WriteLine("Wprowadź  liczbę  elementów do posortowania <1 .. 10>: ");
            
          sizeOfTab = int.Parse(Console.ReadLine());
        }while (sizeOfTab < 0 || sizeOfTab > 10);
    }
    static void CreateTab(){tab = new int[sizeOfTab];}
    static void InsertValuesToTab(int[] tab){...}
    static void Sort(int[] tab){...}
