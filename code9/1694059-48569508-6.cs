    Console.WriteLine("please enter a number: ");
    string num = Console.ReadLine(); // "12329"
    
    int sum = (int)num.Select(n => Char.GetNumericValue(n)).Sum();
    Console.WriteLine(sum); // 17 
   
