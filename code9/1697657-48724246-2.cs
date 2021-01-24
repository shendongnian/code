    using System;
    using System.Linq;
    using System.Text;
    
    namespace StackOverflowTesting
    {
        class Program
        {
            /* Player position */
            static int PlayerX = 1;
            static int PlayerY = 1;
    
            static string ComputeFrameBuffer()
            {
                //What are the current dimensions of the console window
                int consoleWindowHeight = Console.WindowHeight;
                int consoleWindowWidth = Console.WindowWidth - 1;  //-1 prevents line overflow
    
                //Compute framebuffer line-wise
                var lines = new StringBuilder[consoleWindowHeight];
    
                for(int y = 0; y < consoleWindowHeight; y++)
                {
                    //Create the line as a repetition of consoleWindowWidth spaces or other filler.
                    lines[y] = new StringBuilder(string.Join("", Enumerable.Repeat("-", consoleWindowWidth)));
                    for (int x = 0; x < consoleWindowWidth; x++) 
                    {
                        //What do we need to draw at this (x,y) position? is the player here? 
                        if(PlayerX == x && PlayerY == y)
                        {
                            //Yes. Use a '*' for the player "sprite"..
                            lines[y][x] = '*';
                        }
                    }
                }
                //Concatinate all lines
                return string.Join("\n", lines.Select(l => l.ToString()));
            }
    
            static void Main(string[] args)
            {
                bool runGame = true;
                while (runGame)
                {
                    //Render current frame
                    string frame = ComputeFrameBuffer();
                    Console.Clear();
                    Console.Write(frame);
    
                    //Grab next user input
                    var pressedKey = Console.ReadKey(false);
                    //Handle stuff
                    switch (pressedKey.Key)
                    {
                        case ConsoleKey.LeftArrow:
                            PlayerX--;
                            break;
                        case ConsoleKey.RightArrow:
                            PlayerX++;
                            break;
                        case ConsoleKey.UpArrow:
                            PlayerY--; //Coordinate system is upper left = (0,0). Downwards increases Y.
                            break;
                        case ConsoleKey.DownArrow:
                            PlayerY++;
                            break;
                        case ConsoleKey.Escape:
                            runGame = false;
                            break;
                    }
                    //clamp coordinates to be always within bounds
                    int maxY = Console.WindowHeight;
                    int maxX = Console.WindowWidth - 1; 
                    if (PlayerX < 0) PlayerX = 0;
                    if (PlayerX >= maxX) PlayerX = maxX - 1;
                    if (PlayerY < 0) PlayerY = 0;
                    if(PlayerY >= maxY) PlayerY = maxY - 1;
                }
            }
        }
    }
