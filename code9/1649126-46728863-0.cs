    var rnd = new Random();
    :
    public static int Kicker()
    {
      // get integer number in the range 0-99999
      int num = rnd.Next(0, 100000);
      // check the ranges
      if (num < 42546) return 1; // checking for 0 to 42,545
      if (num < 82546) return 2; // 42,546 to 82,545
      if (num < 88796) return 3; // 82,546 to 88,795
      if (num < 95046) return 4; // 88,796 to 95,045
      if (num < 98750) return 5; // 95,046 to 98,749
      return 10;                 // 98,750 to 99,999
    }
