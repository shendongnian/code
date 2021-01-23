    public const int Number = 1; // this works; 1 is a literal
    public const int Number = SomeClass.SomeProperty; // this does not work
    public const int Number = SomeClass.SomeConst; // this works
  
    public const SomeClass Var = new SomeClass(); // does not work
    public const string Var = "test"; // this works as "test" is a literal.
