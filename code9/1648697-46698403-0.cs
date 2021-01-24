    static void TypeLine(string line) {
        for (int i = 0; i < line.Length; ++i) {
            Console.Write(line[i]);
            if (!Console.KeyAvailable)
                System.Threading.Thread.Sleep(40); // Sleep between characters
        }
        Console.Write("\n");
    }
