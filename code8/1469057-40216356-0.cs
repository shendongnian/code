    Console.WriteLine("Enter your sentence:");
    // try not declaring local variable prematurely, but exacly where you want them
    string sentence = Console.ReadLine();
        
    // StringSplitOptions.RemoveEmptyEntries - what if user starts with space? 
    // separate words with two spaces, e.g. "  This   is a test    input  " 
    // we want 5, right? 
    int count = sentence
      .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
      .Length; // Please, notice spelling
    Console.WriteLine(count);   
  
    Console.ReadKey();
