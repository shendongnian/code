    Console.WriteLine("Skriv titeln på det inlägg du vill ta bort:")
    string title = Console.ReadLine();
    for(int x = 0; x < loggbok.Count; x++) //Loopa igenom varje inlägg.
    {
        if(String.Equals(loggbok[x][0], title, StringComparison.OrdinalIgnoreCase)) //Icke skiftlägeskänslig matchning av titeln.
        {
            loggbok.RemoveAt(x); //Matchning funnen.
            break; //Avsluta loopen.
        }
    }
