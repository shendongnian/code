    string inputcost;
        string inputmoney;
        int validcost;
        int validmoney;
        int changereq;       
        while (true)
        {
            Console.Write("Please Enter The Cost, In Pennies, Of The Item You Have Purchased: ");
            inputcost = Console.ReadLine();
            
            if (!(valuecost >=1 && valuecost <=100))
            {
                Console.Write("Please enter value between 1 and 100.");
            }
            
            bool result = int.TryParse(inputcost, out validcost);                      
        
            if (result == true)
            { 
                Console.Write("Valid Value");
            }
            if (result == false)
            {
                Console.Write("Please Enter A Valid Integer Value");
            }        
        }
