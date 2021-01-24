    Console.WriteLine("Enter 1 or 2: ");
    int i = Console.Read(); // Here the user types: 12[Enter]
    // The value of 'i' is now 49 (the ASCII value of 1)
    // Later we do this:
    Console.WriteLine("Enter 3 or 4:");
    int j = Console.Read();
    // The value of 'j' is now 50 (the ASCII value of 2), and the code keeps running 
    // (there is no pause to wait for user input, since it was already in the cache),
