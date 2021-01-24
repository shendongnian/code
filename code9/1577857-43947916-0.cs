    class Animal {}
    class Mammal : Animal {}
    class Tiger : Mammal {}
    class Shape {}
    class Square : Shape {}
    class GreenSquare : Square {}
    
    class B
    {
      public virtual Mammal Frob(Square s) { ... }
    }
    class D : B
    {
      public override SomeReturnType Frob(SomeArgumentType m) { ... }
    }
