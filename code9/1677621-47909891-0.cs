    int highNumber = 0;
    int valueTemp;
    Console.Write("Enter a series of numbers separated by comma: ");
    var userInput = Console.ReadLine();
    string[] array = userInput.Split(',');
    for (var i = 0; i < array.Length; i++)
    {
        if (int.TryParse(array[i], out valueTemp))
        {
            if (valueTemp > highNumber)
            {
                highNumber =  valueTemp;
            }
        }
    }
    
    Console.WriteLine("The largest number is {0}", Convert.ToInt32(highNumber));
