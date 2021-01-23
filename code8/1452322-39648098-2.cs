    Console.WriteLine("Please enter in a five digit number: ");
    string userInput = Console.ReadLine();
    for (int i = 0; i < userInput.Length; i++) {
     char[] ip = userInput.ToCharArray();
     Console.Write(ip[i] + "   ");
    }
    Console.ReadKey();
