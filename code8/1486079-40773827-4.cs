    void SomeMethodWhichThereforeHasAScope()
    {
      Dog origDog = (Dog)dogRef.Target;
      if (origDog != null)
      {
        Console.Write(dogRef.Target == null); // probably going to be false (though sometimes reads get reordered, so there's a chance that happens).
        origDog.Bark();
      }
    
      Console.Write(dogRef.Target == null); // could be true or false
      var sb = new StringBuilder("I'm a string that got referenced in a call to a method");
      Console.Write(sb.ToString());
      Console.Write(dogRef.Target == null); // even more likely to be true.
    }
