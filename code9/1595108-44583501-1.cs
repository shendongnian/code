    delegate List<MyClass> TestDelegate(string arg1, string arg2);
    List<MyClass> Method1(string arg1, string arg2)
    List<MyClass> Method2(string arg1, string arg2)
    
    List<MyClass> = new TestDelegate(Method1);
    List<MyClass> = new TestDelegate(Method2);
