            private static void TryStart(String url, String raw = "")
            {
                var processes = Process.GetProcessesByName(url);
                if (processes!=null && processes.Any())
                {
                    Process.Start(url);
     
                    //Process.Start(processes.First().ProcessName); //This can be used as well to start.
                }
                else
                {
                    Process.Start(raw);
                }
               
            }
