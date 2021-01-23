    partial class MyClass {
        partial void Foo();
    }
    
    // This can be in another file
    partial class MyClass  {
        partial void Foo() {
            Console.WriteLine("Foo");
        }
    }
