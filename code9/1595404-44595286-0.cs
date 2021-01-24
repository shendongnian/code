    int x = 123;
    Action change = () => { Console.WriteLine(x); x = 345; };
    Console.WriteLine(x); // 123
    change(); // 123
    Console.WriteLine(x); // 345
    change(); // 345
    x = 789;
    change(); // 789
    Console.WriteLine(x); // 345
