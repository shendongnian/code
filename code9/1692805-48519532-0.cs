    public enum MyEnum
    {
        MyType1,
        MyType2
    }
    public class MyBaseClass
    {
        
    }
    [MyCustomAttribute(EnumType = MyEnum.MyType1)]
    public class MySubClass : MyBaseClass
    {
        
    }
    [MyCustomAttribute(EnumType = MyEnum.MyType2)]
    public class MyOtherClass : MyBaseClass
    {
    }
