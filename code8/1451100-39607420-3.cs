    public class Base<T>
        where T : Base<T>, new() {
        public static T Instance {
            get {
                return new T();
            }
        }
    }
    public class Derived : Base<Derived> {
        public void SomeFunc() {
            Console.WriteLine("SomeFunc()");
        }
    }
    // in other code
	private T Foo<T>() where T : Base<T>, new() {
        // note that we can't just use T directly here, but that's okay, because we know that T is always going to be at least a Base<T>
	    return Base<T>.Instance;
	}
    
    private void Example() {
        // the type of Base<Derived>.Instance is Derived, so you can call Func() on it
        Base<Derived>.Instance.SomeFunc();
        // can also do this:
        Foo<Derived>().SomeFunc();
    }
