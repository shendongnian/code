    Console.WriteLine((long)int.MaxValue); //Result 2147483647
    Console.WriteLine((long)int.MinValue); //Result -2147483648
    Console.WriteLine((long)int.MaxValue-int.MinValue); //Result 4294967295
    Console.WriteLine((long)2147483647-(-2147483648)); //Same as above
    Console.WriteLine((long)int.MaxValue+int.MinValue); //Result -1
    Console.WriteLine((long)2147483647+(-2147483648)); //Same as above
    Console.WriteLine((long)int.MaxValue+1); //Result 2147483648
    Console.WriteLine((long)2147483647+1); //Same as above
    Console.WriteLine((long)int.MaxValue-int.MaxValue); //Result 0
    Console.WriteLine((long)2147483647-2147483647); //Same as above
    Console.WriteLine((long)int.MaxValue+int.MaxValue); //Result 4294967294
    Console.WriteLine((long)2147483647+2147483647); //Same as above
