    float a = -2.98023224E-08f;
    Console.WriteLine(a); //-2.980232E-08 last two digits lost
    Console.WriteLine(a + 1f); //1 (but actually 0.9999999)
    Console.WriteLine(a + 1f < 1f); //true - treated as 0.9999999
    Console.WriteLine((float)(a + 1f) < 1f); //false - treated as 1
