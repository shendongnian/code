    public class MyClass<A, B> where A : BaseA, B : BaseB {
        public A doSmth(B input)
        {
             return input.someMethod();
        }
    }
