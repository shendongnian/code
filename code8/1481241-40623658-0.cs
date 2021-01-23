       resp3 = Console.ReadLine();
       if (resp3 == "tell me the curent date and time")
       {
          Console.Write(string.Format("{0:HH:mm:ss tt}", DateTime.Now));
       }
       Console.ReadLine();
