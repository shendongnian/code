    static void Main(string[] args)
    {
      Console.WriteLine("Indiquez votre phrase à encoder:");
      string PhraseAEncoder = Console.ReadLine().ToLower(); // alphabet is only in lowercase
      string result = Crypto(PhraseAEncoder, 8); // crypto password "8"
      Console.WriteLine(result);
      result = Crypto(result, -8);  // crypto reverse password "-8"
      Console.WriteLine(result);
      if (string.Equals(result, PhraseAEncoder))
        Console.WriteLine("OK");
      else
        Console.WriteLine("Error");
    }
