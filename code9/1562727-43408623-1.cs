 //File: foo.cs
namespace Space
{
    public class FooClass
    {
        public static int Foo() {return BarClass.Bar();}
    }
}
 //File: bar.cs
namespace Space
{
    internal class BarClass
    {
        public static int Bar() {return 123;}
    }
}
Now, attempt to compile these 2 files into separated assemblies would not compile, which is a correct behavior:
    csc /target:library /out:foo.dll foo.cs
    error CS0103: The name 'Bar' does not exist in the current context
Compiling them together, you will get the library, and then all the internals inside this dll will work as expected.
    csc /target:library /out:foobar.dll foo.cs bar.cs
    # It will generate foobar.dll
So this clarifies my previous question. Yes, we can be sure that "all our internal things will actually be compiled into the same assembly", because otherwise the compile attempt would fail.
