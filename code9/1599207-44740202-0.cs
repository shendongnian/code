    Console.WriteLine(unchecked(int.MaxValue)); //Result 2147483647
    Console.WriteLine(unchecked(int.MinValue)); //Result -2147483648
    Console.WriteLine(unchecked(int.MaxValue-int.MinValue)); //Result -1 overflow
    Console.WriteLine(unchecked(2147483647-(-2147483648))); //Same as above
    Console.WriteLine(unchecked(int.MaxValue+int.MinValue)); //Result -1 no overflow
    Console.WriteLine(unchecked(2147483647+(-2147483648))); //Same as above
    Console.WriteLine(unchecked(int.MaxValue+1)); //Result -2147483648 overflow
    Console.WriteLine(unchecked(2147483647+1)); //Same as above
    Console.WriteLine(unchecked(int.MaxValue-int.MaxValue)); //Result 0
    Console.WriteLine(unchecked(2147483647-2147483647)); //Same as above
    Console.WriteLine(unchecked(int.MaxValue+int.MaxValue)); //Result -2 overflow
    Console.WriteLine(unchecked(2147483647+2147483647)); //Same as above
