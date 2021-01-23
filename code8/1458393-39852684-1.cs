    int num;
    string input;
    
    Console.WriteLine("plz enter your phone  number ");
    input = Console.ReadLine();
    Console.WriteLine("the phone number: {0}", input.replace(" ", "").Replace("-",""));
