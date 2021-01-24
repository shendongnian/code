    void PassByRef(ref int x) {
      x = 42;
    }
    void PassByValue(int x) {
      // This has no effect
      x = 84;
    }
    var Caller() {
      x = 1;
      Console.WriteLine(x); // Writes 1
      PassByRef(ref x);
      Console.WriteLine(x); // Writes 42
      PassByValue(x);
      Console.WriteLine(x); // Writes 42: no change by PassByValue
    }
