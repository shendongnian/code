    string strAppended = string.Empty;
    if (!Directory.Exists(MenGinPath))
    {
        strAppended = MenGinPath + @"Groups\timedmessages.txt";
    }
    else if (!File.Exists(MenGinPath + @"TimedMessages\timedmessages.txt"))
    {
        strAppended = MenGinPath + @"TimedMessages\TimedMessages.txt";
    }
    else
    {
        return;
    }
    Directory.CreateDirectory(strAppended);
    File.WriteAllLines(strAppended, new string[] { "Seperate each message with a new line" });
