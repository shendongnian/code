    int MinVal = 1;    // No magic numbers! You may consider placing them in a config 
    int MaxVal = 100;  // or as static readonly class members (a bit like "const").
    int input = -1;
    for(;;){ // "empty" for-loop = infinite loop. No problem, we break on condition inside.
       bool parseOK = int.TryParse(Console.ReadLine(), out input);
       if( parseOK && input >= MinVal && input <= MaxVal ) break; // Exit loop if input is valid.
       Console.WriteLine( "Errormessage telling user what you expect" );
    }
