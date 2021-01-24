           MarkupClass item1 = new MarkupClass();
           Console.WriteLine("what is the whole sale cost: ");
           string input =  Console.ReadLine(); //getting value in string format
           decimal input_decimal  = Decimal.Parse(input); // caste string input into decimal 
            item1.wholeSaleCost = item1.DoCalculations(input_decimal); // pass it to DoCalculations to do calculation 
