    static void Main()
    {
                List<int> mainList = new List<int>();
                UpdateList(mainList);
                Console.WriteLine(mainList.Count); // prints 0
    }
    
    private static void UpdateList(List<int> list)
    {
                list = new List<int>();
                list.Add(1);
                list.Add(2);
                Console.WriteLine(list.Count); // prints 2 
    }
