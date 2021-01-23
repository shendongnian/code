    class Program
    {
        static int[,] field = new int[3, 3];
        static Player[] p;
        static int i;
        static bool gamerunning = true;
        static Random rnd = new Random();
        static int currentplayer = 0;
        static int playercolumn = 7;
        static int playerline = 7;
        static void Main(string[] args)
        {
            INITIALIZE();
            Console.Clear();
            DrawField();
            currentplayer = rnd.Next(1, 2);
            while (gamerunning == true)
            {
                UPDATE();
            }
            Console.ReadLine();
        }
        public class Player
        {
            public string name { get; set; }
            public char pawn { get; set; }
            public ConsoleColor color { get; set;}
        }
        static void INITIALIZE()
        {
            playerconfiguration();
            DrawField();
        }
        static void playerconfiguration()
        {
            p = new Player[2];
            for (i = 0; i <= 1; i++)
            {
                p[i] = new Player();
                Console.WriteLine("Spieler " + (i + 1) + ", gib deinen Namen ein!");
                p[i].name = Console.ReadLine();
                Console.WriteLine(p[i].name + ", wähle deine Farbe: ");
                ColorConfiguration();
                Console.WriteLine("... und nun dein Symbol z.B. X oder O: ");
                p[i].pawn = Console.ReadKey().KeyChar;
                Console.WriteLine();
            }
        }
        static void ColorConfiguration()
        {
            Console.WriteLine("Gib eine der folgenden Farben ein: blau, pink, gelb, weiss, rot oder dunkelblau");
            bool whatcolorinput = true;
            while (whatcolorinput == true)
            {
                string whatcolor = Console.ReadLine();
                switch (whatcolor)
                {
                    case "blau":
                        p[i].color = ConsoleColor.Cyan;
                        whatcolorinput = false;
                        break;
                    case "pink":
                        p[i].color = ConsoleColor.Magenta;
                        whatcolorinput = false;
                        break;
                    case "gelb":
                        p[i].color = ConsoleColor.Yellow;
                        whatcolorinput = false;
                        break;
                    case "weiss":
                        p[i].color = ConsoleColor.White;
                        whatcolorinput = false;
                        break;
                    case "rot":
                        p[i].color = ConsoleColor.Red;
                        whatcolorinput = false;
                        break;
                    case "dunkelblau":
                        p[i].color = ConsoleColor.DarkCyan;
                        whatcolorinput = false;
                        break;
                    default:
                        Console.WriteLine("Gib eine der folgenden Farben ein: blau, pink, gelb, weiss, rot oder dunkelblau");
                        break;
                }
            }
        }
        static void UPDATE()
        {
            DrawField();
            Console.WriteLine(p[currentplayer].name + ", du bist dran!");
            PlayerInput();
            UpdateField();
            currentplayer = (currentplayer + 1) % 2;
        }
        static void DrawField()
        {
            for (int line = 0; line < field.GetLength(1); line++)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.Write((line + 1) + "|");
                Console.ResetColor();
                for (int column = 0; column < field.GetLength(0); column++)
                {
                    if (field[line, column] == 0)
                    {
                        Console.Write("   ");
                    }
                    else
                    {
                        Console.ForegroundColor = p[field[line, column]-1].color;
                        Console.Write(" " + p[field[line, column] -1].pawn + " ");
                        Console.ResetColor();
                    }
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("  ________");
            Console.WriteLine("   1  2  3");
            Console.ResetColor();
        }
        static void PlayerInput()
        {
            Console.WriteLine("Wähle zuerst eine Spalte: ");
            
            bool lineinput = true;
            while (lineinput == true)
            {
                try
                {
                    playerline = Convert.ToInt32(Console.ReadLine());
                    if (playerline < 1 || playerline > 3)
                    {
                        Console.WriteLine("Wähle eine Spalte.");
                    }
                    else
                    {
                        lineinput = false;
                    }
                }
                catch
                {
                    Console.WriteLine("Wähle eine Spalte.");
                }
            }
            bool columninput = true;
            while (columninput == true)
            {
                try
                {
                    playercolumn = Convert.ToInt32(Console.ReadLine());
                    if (playercolumn < 1 || playercolumn > 3)
                    {
                        Console.WriteLine("Wähle eine Zeile.");
                    }
                    else
                    {
                        columninput = false;
                    }
                }
                catch
                {
                    Console.WriteLine("Wähle eine Zeile.");
                }
            }
            playercolumn -= 1;
            Console.WriteLine("... und nun eine Spalte");
            
            
            //field[line-1, column] = new int();
            
            playerline -= 1;
            field[playerline, playercolumn] = currentplayer+1;
        }
        static void UpdateField()
        {
        }
        static void FINISH()
        {
        }
    }
