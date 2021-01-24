            string page = "http://localhost:8080/api/Stream/testStream";
            //while (!Debugger.IsAttached) Thread.Sleep(500);
            using (HttpClient client = new HttpClient())
            using (var s = await client.GetStreamAsync(page))
            {
                using (StreamReader r = new StreamReader(s))
                {
                    string line = null;
                    while (null != (line = r.ReadLine()))
                    {
                        Console.WriteLine(line);
                    }
                }
            }
