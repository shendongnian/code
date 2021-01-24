    createClients(ref clients);
    static void CreateClients(ref string[] clients)
    {
      //ask how many clients
      int c = Convert.ToInt32(Console.ReadLine());
      clients = new string[c];
    }
