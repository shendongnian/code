    static void Main(string[] args)
    {
       var playerNames = new List<Names>(); 
       //I assume that getPlayerList() is a function that will populate your list with objects of type Names
       playerNames = getPlayerList(ref totalPlayers);
       //you can return the entire list of objects and retrieve whatever values you need using a list
        foreach (var p in players)
        {
           Console.WriteLine( "Id " + p.Id );
           Console.WriteLine( "Name " + p.Name );
        }
        //Or create just a list of names
        var listOfNames = new list<string>();
        foreach (var p in players)
        {
           listOfNames.add(p.Name);
        }
        //Will print the first index in the list
        Console.WriteLine( listOfNames[0]);
    }
