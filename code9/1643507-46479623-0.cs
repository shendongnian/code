      int seed, a, c, mod, it, numrand, residuo;
      float division;
      seed = 23;
      a = 34 ;
      c = 17;
      mod = 45;
      it = 100;
      for (int i = 1; i <= it; i++) {
        string newLine = Environment.NewLine;
        numrand = seed * a + c;
        residuo = numrand % mod;
        division = numrand / mod;
        //residuo = seed;
        seed = residuo;
        Console.WriteLine("{2}",numrand, residuo, division);
      }
    Output:
    10
    7
    6
    14
    25
    10
    32
    29
    29
    3
    13
    33
    21
    18
    17
    26
    2
    22
    10
    7
    6
    14
    25
