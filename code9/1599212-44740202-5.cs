    Console.WriteLine(unchecked((int)2147483647)); //Result 2147483647
    Console.WriteLine(unchecked((int)2147483648)); //Result -2147483648 overflow
    Console.WriteLine(unchecked((int)2147483649)); //Result -2147483647 overflow
    Console.WriteLine(unchecked((int)2147483649)); //Result -2147483647 overflow
    Console.WriteLine(unchecked((int)2147483650)); //Result -2147483646 overflow
    Console.WriteLine(unchecked((int)2147483651)); //Result -2147483645 overflow
