    if (!File.Exists("FILENAME.txt")) // If file does not exists
    {
        File.Create("FILENAME.txt").Close(); // Create file
        using (StreamWriter sw = File.AppendText("FILENAME.txt"))
        {
            sw.WriteLine("WRITE SOME TEXT"); // Write text to .txt file
        }
    }
    else // If file already exists
    {
        // File.WriteAllText("FILENAME.txt", String.Empty); // Clear file
        using (StreamWriter sw = File.AppendText("FILENAME.txt"))
        {
            sw.WriteLine("WRITE SOME TEXT"); // Write text to .txt file
        }
    }
