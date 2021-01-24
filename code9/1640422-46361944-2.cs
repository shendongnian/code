    string[] moods = { "good", "alright", "great" };
    string name, chosenMood;
    Console.WriteLine( "What's your name?" );
    name = Console.ReadLine();
    Console.WriteLine( "How are you doing today?" );
    chosenMood = Console.ReadLine();
    if( moods.Any(mood => chosenMood.ToLower().Contains(mood)) )
    {
        Console.WriteLine( "Good to hear that!" );
    }
    else
    {
        Console.WriteLine( "Ah well" );
    }
    Console.ReadKey();
