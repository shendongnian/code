    class Program
    {
        static int counter = 0;
        static readonly ThreadLocal<Random> random =
            new ThreadLocal<Random>(() => new Random(Interlocked.Increment(ref counter)));
        static List<Thread> players = new List<Thread>();
        static void Main(string[] args)
        {
            string[] playerNames = {"David", "James", "Mike" };
            foreach(string name in playerNames)
            {
                Thread T = new Thread(new ThreadStart(PlayerShot));
                T.Name = name;
                players.Add(T);
            }
            Console.WriteLine("Waiting for Players to Shoot...\n");
            foreach (Thread player in players)
            {
                player.Start();
            }
            // wait for all players to be done shooting
            foreach (Thread player in players)
            {
                player.Join();
            }
            Console.Write("\nPress [Enter] to quit.");
            Console.ReadLine();
        }
        public static void PlayerShot()
        {
            try
            {
                for (int i = 0; i < 3; i++)
                {
                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(random.Value.Next(3, 11))); // 3 to 10 (INCLUSIVE) Second Delay between shots
                    Console.WriteLine("{0} shot {1}\n", Thread.CurrentThread.Name, random.Value.Next(0, 101)); // 0 to 100 (INCLUSIVE)
                }
            }
            catch (Exception ex) { }
        }
    }
