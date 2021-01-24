    string[] lines = File.ReadAllLines(@"C:\Text\TextFile.txt");
    for(int indexY = 0; indexY < lines.Length; indexY++){
        string[] lineEntries = lines[indexY].Split('.');
        for(int indexX = 0; indexX < lineEntries; indexX++){
            // here you have one number by accessing
            // it with lineEntries[indexX]
            Console.Write(lineEntries[indexX]);
        }
        Console.WriteLine();
    }
