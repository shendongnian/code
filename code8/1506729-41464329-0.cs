    class Foo<T>
    {
      private static int Counter;
      public static int DoCount() => Counter++;
      public static bool IsOk() => true;
    }
    Foo<string>.DoCount(); // 0
    Foo<string>.DoCount(); // 1
    Foo<object>.DoCount(); // 0
