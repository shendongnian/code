    class Animal
    {
      public virtual void Eat(Apple a) { ... }
    }
    class Giraffe : Animal
    {
      public void Eat(Food f) { ... }
      public override void Eat(Apple a) { ... }
    }
