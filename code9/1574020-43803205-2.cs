     Game game = new game(3); 
     game.Lines.Add(123); 
     game.Lines.Add(456); 
     // Board: 3; Lines: 123, 456
     Console.Write("Board: {0}; Lines: {1}", game.Board, string.Join(", ", game.Lines));
