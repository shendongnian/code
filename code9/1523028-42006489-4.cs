    static void Main()
    {
                List<int> mainList = new List<int>();
                UpdateList(mainList);
                Console.WriteLine(mainList.Count); // prints 0
    }
    
    private static void UpdateList(List<int> numbers)
    {
                numbers = new List<int>();
                numbers.Add(1);
                numbers.Add(2);
                Console.WriteLine(numbers.Count); // prints 2
    }
