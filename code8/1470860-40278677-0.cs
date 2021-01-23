     double mealCost, tipPercent, taxPercent;
     Console.WriteLine("Enter values for Meal Cost, Tip percentage and tax percentage");
     if (!double.TryParse(Console.ReadLine(), out mealCost))
     {
         Console.WriteLine("Invalid input for meal Cost");
     }
     if (!double.TryParse(Console.ReadLine(), out tipPercent))
     {
         Console.WriteLine("Invalid input for Tip percentage");
     }
    
     if (!double.TryParse(Console.ReadLine(), out taxPercent))
     {
         Console.WriteLine("Invalid input for Tip tax Percent");
     }
     double tip = (mealCost * (tipPercent / 100));
     double tax = (mealCost * (taxPercent / 100));
     double totalCost = mealCost + tip + tax;
     Console.WriteLine("The total meal cost is {0}", totalCost.ToString("C0"));
    
     Console.ReadLine();
