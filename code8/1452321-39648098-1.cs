    Console.WriteLine("Please enter in a five digit number: ");
    string userInput = Console.ReadLine();
    for (int i = 0; i < userInput.Length; i++) {
     char[] ip = userInput.ToCharArray();
     // Trim last number whitespaces
     if (userInput.Length == 5) {
      Console.Write((ip[i] + "   ").TrimEnd());
     }
    }
    Console.ReadKey();
