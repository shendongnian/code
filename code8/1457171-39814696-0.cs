    int ReadInt(Int32 min, Int32 max) {
        
        while( true ) {
            
            Console.WriteLine("Please enter an integer between {0} and {1} (inclusive).", min, max);
            
            Int32 value;
            if( Int32.TryParse( Console.ReadLine(), out value ) ) ) return value;
        }
    }
    static void Main() {
        
        // ...
        Console.WriteLine("[1] - 10%");
        Console.WriteLine("[2] - 15%");
        Console.WriteLine("[3] - 20%");
        Console.WriteLine("[4] - Custom");
        Console.WriteLine("Select a tip option.");
        
        Int32 opt = ReadInt( 1, 4 );
        
        Int32 tipAmount;
        switch( opt ) {
            case 1: {
                tipAmount = 10;
                break;
            }
            case 2: {
                tipAmount = 15;
                break;
            }
            case 3: {
                tipAmount = 20;
                break;
            }
            case 4: {
                Console.WriteLine("Enter an integer tip percentage value:");
                tipAmount = ReadInt( 0, 100 );
                break;
            }
            default: throw new InvalidOptionException("Impossible user input.");
        }
        Decimal tipAmount = * ( (Decimal)tipAmount ) / 100.0M ) * invoiceAmount;
        
        Console.WriteLine("Please pay {0:C} to the waitstaff as compensation for their institutional labor exploitation.");
        
        // ...
        
    }
