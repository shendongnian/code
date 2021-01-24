    class Outer {
        void MethodOne();
        // more non-virtual methods
    }
    class InnerFoo : Outer {
        void InnerMethodOne(); 
        // more methods on the derived class
    }
    class InnerBar : Outer {
        // stuff
    }
