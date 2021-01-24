    int highNumber = 0;
    int valueTemp;
    Console.Write("Enter a series of numbers separated by comma: ");
    var userInput = Console.ReadLine();
    string[] array = userInput.Split(',');
    List<int> intList = new List<int>();
    for (var i = 0; i < array.Length; i++)
    {
        if (int.TryParse(array[i], out valueTemp))
        {
            intList.Add(valueTemp);
        }
    }
    Console.WriteLine("The largest number is {0}", intList.Max());
