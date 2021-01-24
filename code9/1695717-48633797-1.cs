    private static readonly Random Rnd = new Random();
    private static void Main()
    {
        // Initialize all moves to false
        bool[] allMoves = new bool[64];
        for (int i = 0; i < allMoves.Length; i++) allMoves[i] = false;
        // Pretend a move was made and set some to true
        allMoves[0] = true;
        allMoves[3] = true;
        allMoves[5] = true;
        // Get ALL indexes of 'false' items (currently everything except 0, 3, and 5)
        var validIndexes = GetIndexesOfFalseItems(allMoves).ToList();
        // Choose a random item from that list
        var randomValidIndex = validIndexes[Rnd.Next(validIndexes.Count)];
        // Now we get our next move from our main list at that index
        var nextMove = allMoves[randomValidIndex];
        // Rest if game code...
    }
