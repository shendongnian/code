    Class B<T> : IA<T>
    {
      T Value;
    }
    Class A<T1, T2> : IA<T1>
    {
      T1 Value;
      public B<T2> saveClassA;
    }
    var A1= new A<int, string>(123);
    var B2 = new B<string>("hihi");
    A1.saveClassA = B2;
