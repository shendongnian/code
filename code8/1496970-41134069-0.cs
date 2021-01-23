    public class Parent
    {
      public int age;
      public static Parent operator + (Parent a, Parent b)
      {
        Parent c = new Parent();
        AddImplementation(a, b, c);
        return c;
      }
      protected static void AddImplementation(Parent a, Parent b, Parent sum)
      {
        sum.age = a.age + b.age;
      }
    }
    public class Child : Parent
    {
      public static Child operator + (Child a, Child b)
      {
        Child c = new Child();
        AddImplementation(a, b, c);
        return c;
      }
    }
    
