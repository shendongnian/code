    public static int GetPriceWithString(this Test test, string str)
    {
        switch (test)
        {
             case Test.AA:
                 break;
             case Test.BB:
                 break;
             case Test.CC:
                 break;
             case Test.DD:
                 break;
             default:
                 throw new ArgumentOutOfRangeException(nameof(test), test, null);
         }
    }
