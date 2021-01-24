    string messagePath = Path.Combine(MenGinPath, "TimedMessages");
    string fileName = Path.Combine(messagePath, "timedmessages.txt");
    // call the create even if it exists. The CreateDirectory checks the fact
    // by itself and thus, if you add your own check, you are checking two times.
    Directory.CreateDirectory(messagePath);
    if (!File.Exists(fileName)
         File.WriteAllLines(fileName, new string[] { "Seperate each message with a new line" });
