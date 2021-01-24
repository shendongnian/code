    namespace test
    {
        class Program
        {
            public static void Main(string[] args)
            {
                MediaPlayer player = new MediaPlayer();
                player.Open(new Uri(System.Environment.CurrentDirectory + "\resources\warn.mp3", UriKind.Relative));
                player.Play();
                Console.ReadKey();
            }
        }
    }
