    string name = "";
    int sum = 0;
    Console.WriteLine("What's you name?");
    name = Console.ReadLine();
    foreach (char c in name)
    {
        Console.WriteLine((int)c);
        sum += (int) c; // This line will add all the values together
    }
    Console.WriteLine(sum.ToString()); // If you want to print to the console the sum.
    // sum = // This line will prevent compilation. Does it need removing?
    Console.ReadKey();
