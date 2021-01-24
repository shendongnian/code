    class MyClass
    {
        public int MyProperty {get; set;}
    }
    void Main()
    {
        var t=new MyClass[3]{new MyClass {MyProperty=1},new MyClass {MyProperty=2},new MyClass {MyProperty=3}};
        var a=t[0]; //ref int a=t[0];
        a.MyProperty+= 10;
        System.Console.WriteLine("a={0}", a.MyProperty);   //11
        System.Console.WriteLine("t[0]={0}", t[0].MyProperty); //11
    }
