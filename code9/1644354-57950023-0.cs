    {
    Console.Write("Insert the number"); 
    number = Convert.ToInt32(Console.ReadLine()); 
    Console.Write("Equals" + Addition(number).ToString());
    Console.ReadKey();
    }
    
    // Operation that returns the addition of the digits of a number 
    
    static int Addition(int number){
    int acum = 0; 
    
    while (num != 0){
    var digit = number % 10;
    acum += digit; 
    number = number / 10; 
    }
    
    return acum;
    
    		}
    	}
    }
