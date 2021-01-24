    private static void UpdateList(List<int> numbers)
    {
                    //numbers = new List<int>(); remove that
                    numbers.Add(1);
                    numbers.Add(2);
                    Console.WriteLine(numbers.Count); // prints 2. 'numbers' still holds the reference the the list from the main 
    }
