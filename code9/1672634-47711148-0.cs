    public static void Main()
    {
        MyObjType obj = new MyObjType();
        List<MyObjType> list = obj.Funct(obj); // still works as expected
        SomeOtherClass obj2 = new SomeOtherClass();
        obj2.Funct(obj2); // uses the correct one, now
    }
