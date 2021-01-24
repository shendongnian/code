    interface IFoo
    {
        void Foo();
    }
    class Base: IFoo
    {
         public void Foo() { Console.WriteLine("Base Foo!");
    }
    class Derived: Base { }
    
    class DerivedWithATwist: Base, IFoo //redeclares interface
    {
        void IFoo.Foo() { Console.WriteLine("Derived Foo!");
    }
