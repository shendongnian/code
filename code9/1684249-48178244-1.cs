    class C : I<Mammal, Mammal>
    {
      public Mammal M(F<Mammal, Mammal> f) {
        return f(new Giraffe());
      }
    }
