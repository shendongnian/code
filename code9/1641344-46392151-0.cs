    string messagePath = Path.Combine(MenGinPath, @"Groups\TimesMessages");
    string filePath = Path.Combine(messagePath, "timedmessages.txt");
    // call the create even if it exists. The CreateDirectory checks the fact
    // by itself and thus you are checking two times.
    Directory.CreateDirectory(messagePath);
    if (!File.Exists(filePath)
         File.WriteAllLines(filePath, new string[] { "Seperate each message with a new line" });
