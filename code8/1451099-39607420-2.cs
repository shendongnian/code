    class Base<T> where T : Base<T> {
        public static T SomeMethod() { ... }
    }
    
    class Derived : Base<Derived> {
    
    }
    
    public void Main() {
        Derived d = Derived.SomeMethod();  // correctly returns an object of type Derived, even though method is defined in base class
    }
