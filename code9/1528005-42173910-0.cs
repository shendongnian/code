        string line;
        while ((line = Console.ReadLine()) != "exit")
        {
             _hub.Invoke("GetByName", line).Wait();
        }
