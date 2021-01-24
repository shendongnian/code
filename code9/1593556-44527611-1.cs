            var spotify = Process.GetProcessesByName("Spotify");
            foreach (var song in spotify)
            {
                Console.WriteLine(song.MainWindowTitle);
            }
            Console.ReadLine();
