    int index = 0, input, averageInput;
    var collection = new List<int>();
    if(int.TryParse(Console.ReadLine(), out input) && input >= 2)
    {
         while(index <= input)
         {
              if(int.TryParse(Console.ReadLine(), out averageInput)
                 collection.Add(averageInput);
    
              index++;
         }
       
         var sum = collection.Sum();
         var average = collection.Average();
    }
