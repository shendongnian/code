    public static void Main(string[] args)
    {
        var diceGame = new DiceGame(2, new DicePlayer("Bill"), new DicePlayer("Sam"));
        diceGame.PlayGame();
        Console.ReadKey();
    }
    
    internal class DiceGame
    {
        private readonly int rounds;
        private readonly DicePlayer player1;
        private readonly DicePlayer player2;
        public DiceGame(int rounds, DicePlayer player1, DicePlayer player2)
        {
            this.rounds = rounds;
            this.player1 = player1;
            this.player2 = player2;
        }
        public void PlayGame()
        {
            var die = new Die();
            for (var i = 0; i < rounds; i++)
            {
                player1.TakeTurn(die);
                player2.TakeTurn(die);
            }
            if (player1.CurrentScore == player2.CurrentScore)
            {
                Console.WriteLine($"Game is drawn - {player1.Name} has {player1.CurrentScore} and {player2.Name} has {player2.CurrentScore}");
            }
            else if (player1.CurrentScore > player2.CurrentScore)
            {
                Console.WriteLine($"{player1.Name} wins - {player1.Name} has {player1.CurrentScore} and {player2.Name} has {player2.CurrentScore}");
            }
            else
            {
                Console.WriteLine($"{player2.Name} wins - {player1.Name} has {player1.CurrentScore} and {player2.Name} has {player2.CurrentScore}");
            }
        }
    }
    internal class DicePlayer
    {
        public DicePlayer(string name)
        {
            Name = name;
        }
        public string Name { get; }
        public int CurrentScore { get; private set; }
        public void TakeTurn(Die die)
        {
            Console.WriteLine($"Player {Name}");
            //In this game, only the highest dice is put aside each time.
            var roundScore = 0;
            for (int i = 0; i < 3; i++)
            {
                Console.Write($"Turn {i + 1}: rolling ");
                var max = 0;
                for (int j = 0; j < 3 - i; j++)
                {
                    var roll = die.NextRoll();
                    Console.Write($"{roll} ");
                    if (roll > max)
                    {
                        max = roll;
                    }
                }
                Console.WriteLine($", keeping {max}");
                roundScore += max;
            }
            Console.WriteLine($"Score for round {roundScore}");
            Console.WriteLine();
            CurrentScore += roundScore;
        }
    }
    internal class Die
    {
        private readonly Random rng;
        public Die()
        {
            rng = new Random();
        }
        public int NextRoll()
        {
            return rng.Next(1, 7);
        }
    }
