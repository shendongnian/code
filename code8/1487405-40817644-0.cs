    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace CalculatingGame
    {
        class Program
        {
            static void Main(string[] args)
            {
                // Add different difficulty options
                Dictionary<string, Difficulty> DifficultyOptions = new Dictionary<string, Difficulty>();
                DifficultyOptions.Add("easy", new EasyDifficulty());
                DifficultyOptions.Add("medium", new MediumDifficulty());
                DifficultyOptions.Add("hard", new HardDifficulty());
    
                // Add different game options
                Dictionary<string, GameType> GameOptions = new Dictionary<string, GameType>();
                GameOptions.Add("additive", new GameAdditive());
                GameOptions.Add("subtractive", new GameSubtractive());
                GameOptions.Add("randomize", new GameRandomize());
    
                // Default game settings at start up
                string GameDiff = "easy";
                string GameMode = "additive";
    
                Console.WriteLine("Welcome to Verkade's Calculating Game.");
                Console.WriteLine("By default game difficulty has been set to " + GameDiff);
                Console.WriteLine("Type in the following commands to change that:");
    
                // This will take out all possible options out of DifficultOptions variable, and display them
                foreach (KeyValuePair<string, Difficulty> kvp in DifficultyOptions)
                {
                    Console.WriteLine("/difficulty " + kvp.Key);
                }
    
                Console.WriteLine("");
    
                Console.WriteLine("By default game mode has been set to " + GameMode);
                Console.WriteLine("Type in the following commands to change that:");
    
                // This will take out all possible options out of game options and display them
                foreach (KeyValuePair<string, GameType> GameTypes in GameOptions)
                {
                    Console.WriteLine("/gamemode " + GameTypes.Key);
                }
    
                Console.WriteLine("");
    
                Console.WriteLine("When you're done setting up, type in /start to start the game,");
                Console.WriteLine("/stop to stop the game. /exit to stop entirely.");
    
                //This will keep the instance of the game once started
                Game CurrentGame = null;
    
                //this will keep the program alive. By typing /exit, it will turn into false, and stops the program.
                bool KeepProgramAlive = true;
    
                //This is a loop that keeps on listening to your input
                while (KeepProgramAlive)
                {
                    // This will split up the users input, when a space is used.
                    // This way the first cut will contain /start, /stop, /gamemode, etc. It will be stored as 'UserInput[0]'
                    // In the second cut, which is 'UserInput[1]', things like 'easy', 'medium', 'hard', 'subtractive', etc will be stored
                    string[] UserInput = Console.ReadLine().Split(' ');
                    switch (UserInput[0])
                    {
                        case "/exit":
                            {
                                KeepProgramAlive = false;
                                break;
                            }
                        case "/start":
                            {
                                if (DifficultyOptions.ContainsKey(GameDiff) && GameOptions.ContainsKey(GameMode))
                                {
                                    Console.WriteLine("Game has been set up. When you're ready, press Enter so you'll get your first question");
                                    CurrentGame = new Game(DifficultyOptions[GameDiff], GameOptions[GameMode]);
                                }
                                break;
                            }
                        case "/stop":
                            {
                                if (CurrentGame != null)
                                {
                                    CurrentGame.Stop();
                                    CurrentGame = null;
                                    Console.WriteLine("Game has been stopped. You can not change settings and start again if you like.");
                                }
                                break;
                            }
                        case "/gamemode":
                            {
                                // checking the length to see there are 2 values. /gamemode is 1 of them. 'subtractive' is another one.
                                if (UserInput.Length >= 2)
                                {
                                    // very important, because i am using a dictionary, i can check whether the gamemode exists or not
                                    if (GameOptions.ContainsKey(UserInput[1]))
                                    {
                                        Console.WriteLine("You have changed gamemode to " + UserInput[1]);
                                        GameMode = UserInput[1];
                                    }
                                    else
                                    {
                                        Console.WriteLine("That gamemode does not exist");
                                    }
                                }
                                break;
                            }
                        case "/difficulty":
                            {
                                if (UserInput.Length >= 2)
                                {
                                    if (DifficultyOptions.ContainsKey(UserInput[1]))
                                    {
                                        Console.WriteLine("You have changed the difficulty to " + UserInput[1]);
                                        GameDiff = UserInput[1];
                                    }
                                    else
                                    {
                                        Console.WriteLine("That difficulty does not exist");
                                    }
                                }
                                break;
                            }
                        default:
                            {
                                // checking if the game has started, and if so, Handler in the game-class will check your input
                                if (CurrentGame != null)
                                {
                                    int NumberGiven;
                                    Int32.TryParse(UserInput[0], out NumberGiven);
                                    CurrentGame.Handler(NumberGiven);
                                }
                                break;
                            }
                    }
                }
            }
        }
    }
