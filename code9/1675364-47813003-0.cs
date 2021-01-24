    do{
       // Hint: consider using try/catch or better TryParse to catch
       //       a user input that is not an integer.
       input = int.Parse(Console.ReadLine());
       if( input < 1 || input > 100 )
       {
           // TODO write error message
       }
    }while( input < 1 || input > 100 );
