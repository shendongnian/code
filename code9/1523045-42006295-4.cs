        public interface IHello
        {
            string SayHello();
        }
        public class Foo : IHello
        {
            public string SayHello() => "Foo says hello!";
        }
        public class DerivedFoo : Foo { }
        public class AnotherDerivedFoo : Foo, IHello
        {
            string IHello.SayHello() => "AnotherDerivedFoo says hello!";
        }
    
    And now:
        IHello foo = new Foo();
        IHello derivedFoo = new DerivedFoo();
        IHello anotherDerivedFoo = new AnotherDerivedFoo();
        Console.WriteLine(foo.SayHello()); //prints "Foo says hello!"
        Console.WriteLine(derivedFoo.SayHello()); //prints "Foo says hello!"
        Console.WriteLine(anotherDerivedFoo.SayHello()); //prints "AnotherDerivedFoo says hello!" !!!
    Your question probably refers to `Foo` and `DerivedFoo` *but* a seldom known feature of the language is `AnotherDerivedFoo` where you basically reimplement the interface with different behavior.
    Do note however the following: 
        var anotherDerivedFoo = new AnotherDerivedFoo(); //reference is typed AnotherDerivedFoo
        Console.WriteLine(anotherDerivedFoo.SayHello()); //prints "Foo says hello!"
    This is due to the fact that you can not reimplement the *implicit* implementation of the interface.
