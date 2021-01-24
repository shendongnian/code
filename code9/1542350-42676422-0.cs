    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main (string[] args)
            {
                var game = new TicTacToe (
                    (x) => new UserAgent (x, "John"),
                    (x) => new RandomAgent (x));
                game.Play ();
                Console.ReadKey ();
            }
        }
        public interface IGame
        {
            IMove[] GetAvailableMoves ();
        }
        public interface IMove
        {
            void MakeMove ();
            string Description { get; }
        }
        public interface IAgent
        {
            string Name { get; }
            IMove SelectMove ();
        }
        public delegate IAgent AgentCreator (IGame game);
        public class RandomAgent : IAgent
        {
            private readonly IGame game;
            private readonly Random random = new Random ();
            public RandomAgent (IGame game)
            {
                this.game = game;
            }
            public string Name => "Computer (random moves)";
            public IMove SelectMove ()
            {
                var availableMoves = game.GetAvailableMoves ();
                int moveIndex = random.Next (availableMoves.Length);
                return availableMoves[moveIndex];
            }
        }
        public class UserAgent : IAgent
        {
            private readonly IGame game;
            public UserAgent (IGame game, string playerName)
            {
                this.game = game;
                Name = playerName;
            }
            public string Name { get; }
            public IMove SelectMove ()
            {
                var availableMoves = game.GetAvailableMoves ();
                Console.WriteLine ("Choose your move:");
                for (int i = 0; i < availableMoves.Length; i++)
                {
                    Console.WriteLine (i + " " + availableMoves[i].Description);
                }
                int selectedIndex = int.Parse (Console.ReadLine ());
                return availableMoves[selectedIndex];
            }
        }
        public class TicTacToe : IGame
        {
            enum CellState { Empty = 0, Circle, Cross }
            CellState[] board = new CellState[9]; // 3x3 board
            int currentPlayer = 0;
            private IAgent player1, player2;
            public TicTacToe (AgentCreator createPlayer1, AgentCreator createPlayer2)
            {
                player1 = createPlayer1 (this);
                player2 = createPlayer2 (this);
            }
            public void Play ()
            {
                PrintBoard ();
                while (GetAvailableMoves ().Length > 0)
                {
                    IAgent agent = currentPlayer == 0 ? player1 : player2;
                    Console.WriteLine ($"{agent.Name} is doing a move...");
                    var move = agent.SelectMove ();
                    Console.WriteLine ("Selected move: " + move.Description);
                    move.MakeMove (); // apply move
                    PrintBoard ();
                    if (IsGameOver ()) break;
                    currentPlayer = currentPlayer == 0 ? 1 : 0;
                }
                Console.Write ("Game over. Winner is = ..."); // some logic to determine winner
            }
            public bool IsGameOver ()
            {
                return false;
            }
            public IMove[] GetAvailableMoves ()
            {
                var result = new List<IMove> ();
                for (int i = 0; i < 9; i++)
                {
                    var cell = board[i];
                    if (cell != CellState.Empty) continue;
                    int index = i;
                    int xpos = (i % 3) + 1;
                    int ypos = (i / 3) + 1;
                    var move = new Move ($"Set {CurrentPlayerSign} on ({xpos},{ypos})", () => 
                    {
                        board[index] = currentPlayer == 0 ? CellState.Cross : CellState.Circle;
                    });
                    result.Add (move);
                }
                return result.ToArray ();
            }
            private char CurrentPlayerSign => currentPlayer == 0 ? 'X' : 'O';
            public void PrintBoard ()
            {
                Console.WriteLine ("Current board state:");
                var b = board.Select (x => x == CellState.Empty ? "." : x == CellState.Cross ? "X" : "O").ToArray ();
                Console.WriteLine ($"{b[0]}{b[1]}{b[2]}\r\n{b[3]}{b[4]}{b[5]}\r\n{b[6]}{b[7]}{b[8]}");
            }
        }
        public class Move : IMove // Generic move, you can also create more specified moves like ChessMove, TicTacToeMove etc. if required
        {
            private readonly Action moveLogic;
            public Move (string moveDescription, Action moveLogic)
            {
                this.moveLogic = moveLogic;
                Description = moveDescription;
            }
            public string Description { get; }
            public void MakeMove () => moveLogic.Invoke ();
        }
    }
