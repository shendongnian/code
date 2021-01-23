    public int Func()
    {
      return 25;
    }
    
    public class MyProgram {
      public static void Main() {
        ClassToTest instance = new ClassToTest();
        int number = instance.func();
        //number will be 25
      }
    }
