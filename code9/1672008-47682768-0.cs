    string[] files = Directory.GetFiles(@"C:\Users\Admin\Music\Playlists", "*", SearchOption.AllDirectories);
    StringBuilder sb = new StringBuilder();
    
    for (int i = 0; i < files.Length; i++)
    {
        sb.AppendLine($"{i + 1}. {Path.GetFileNameWithoutExtension(files[i])}");
        // Each line will be something like: Number. NameOfTheSong
    }
    
    // Only save to the file when everything is done
    File.WriteAllText("E:\\songs.txt", sb.ToString());
    Console.WriteLine("Press any key to exit");
    Console.ReadLine();
