            Console.WriteLine("Enter the MealCost");
            decimal mealCost = Decimal.Parse(Console.ReadLine());
            int tipPercent = Int32.Parse(Console.ReadLine());
            int taxPercent = Int32.Parse(Console.ReadLine());
            // calulation Part
            decimal tip = mealCost * ((decimal)tipPercent / 100m);
            decimal tax = mealCost * ((decimal)taxPercent / 100m); 
            decimal totalCost = mealCost + tip + tax;
            Console.WriteLine(Math.Round(totalCost));
            Console.ReadLine();
