    DateTime now = DateTime.Now;
        using (StreamWriter writer = new StreamWriter(logFile, !replaceExistingFile))
        {
            writer.WriteLine(now.ToString("MM-dd-yyyy HH:mm:ss")  + "- " + message);
            writer.WriteLine(" ");
        }
    }
