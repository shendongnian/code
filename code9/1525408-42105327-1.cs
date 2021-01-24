    public static void ProcessQueueMessage([TimerTrigger("00:00:03")] TimerInfo timerInfo, TextWriter log)
            {
                string instance = Environment.GetEnvironmentVariable("WEBSITE_INSTANCE_ID");
                string newMsg = $"WEBSITE_INSTANCE_ID：{instance}, timestamp：{DateTime.Now}";
                string path;
                if (Environment.GetEnvironmentVariable("HOME")!=null)
                {
                    path = Environment.GetEnvironmentVariable("HOME") + @"\site\wwwroot" + @"\test.txt"; 
                }
                else
                {
                    path = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory())) + @"\test.txt";
                }
                string template = File.ReadAllText(path);
                log.WriteLine($"NewMsge: {newMsg},file Content:{template}");
                Console.WriteLine($"NewMsge: {newMsg},file Content:{template}");
            }
