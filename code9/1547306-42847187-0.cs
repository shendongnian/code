    class Program
    {
      static void Test(ThingCreator creator)
      {
        Console.WriteLine(creator.Method.ReturnType);
      }
      static IThing Anon1() 
      {
        return new Foo();
      }
      static IThing Anon2()
      {
        return new Bar();
      }
      static void Main()
      {
        Test(new ThingCreator(Foo.Create));
        Test(new ThingCreator(Bar.Create));
        Test(new ThingCreator(Program.Anon1));
        Test(new ThingCreator(Program.Anon2));
      }
    }
