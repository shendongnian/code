     // We want name (string), say "Test" not just character 'T'
     string name = Console.ReadLine();
     int phonno = 0;
     // Ask for a number until a correct one is provided
     while (!int.TryParse(Console.ReadLine(), out phonno)) {
       Console.WriteLine("Incorrect number, please put the number again."); 
     } 
