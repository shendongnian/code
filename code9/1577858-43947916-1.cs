    class D : B {
      private Tiger FrobPrivate(Square s) { ... }
      public override Mammal Frob(Square s) 
      { 
        return this.FrobPrivate(s);
      }
      public new Tiger Frob(Square s)
      { 
        return this.FrobPrivate(s);
      }
    }
