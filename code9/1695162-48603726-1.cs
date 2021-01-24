    List<object> log = new List<object>();
                JsonSerializer serializer = new JsonSerializer();
            string path = @"C:\Users\COCON\source\repos\DiscordAdmin\DiscordAdmin\Logs\Purge.json";
            if (System.IO.File.Exists(path))
            {
                using (System.IO.StreamReader reader = new System.IO.StreamReader(path))
                {
                    Newtonsoft.Json.JsonReader jreader = new Newtonsoft.Json.JsonTextReader(reader);
                    log = serializer.Deserialize<List<object>>(jreader);
                }
            }
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(path, false))
            {
                object logEntry = LocalTime + ": " + Sender + " has executed the purge command on " + message + " messages";
                log.Add(logEntry);
                
                //serialize object directly into file stream
                //string json = serializer.Serialize(account, Formatting.Indented);
                serializer.Serialize(file, log); //Serialize the time, the author of the command and how many messages they purged
            }
