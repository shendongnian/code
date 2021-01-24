    static void Main(string[] args)
            {
    
    
            String strPath = @"C:\jimmybuffett";
            String strSong = "Fins";
    
            var songs = from song in Directory.GetFiles(strPath, "*", SearchOption.AllDirectories)
                        where File.ReadAllLines(song).Any(x=>x.Contains(strSong))
                        select song;
    
            foreach(var song in songs)
            {
                Console.WriteLine(song);
            }
    
            Console.WriteLine("Press <enter> to continue");
            Console.ReadLine();
        }
