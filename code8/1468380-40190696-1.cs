    private static List<Move[]> GetPossibleMoves(int NumberOfPlayers)
    {
        int Combination = 0;
        List<Move[]> PossibleMoves = new List<Move[]>();
        while (true)
        {
            List<int> Digits = IntToString(Combination, new char[] { '0', '1', '2', '3' })
                .PadLeft(NumberOfPlayers, '0')
                .Select(D => Convert.ToInt32(D.ToString()))
                .ToList();
    
            if (Digits.Count() > NumberOfPlayers)
            {
                break;
            }
            else
            {
                Move[] Moves = new Move[NumberOfPlayers];
                for (int Player = 0; Player < NumberOfPlayers; Player++)
                {
                    Moves[Player] = (Move)Digits[Player];
                }
                PossibleMoves.Add(Moves);                 
            }
            Combination++;
        }
        return PossibleMoves;
    }
