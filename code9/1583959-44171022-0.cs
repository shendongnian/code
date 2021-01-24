    class Outer {
        void MethodOne(); // Non-virtual
        // more non-virtual methods
    }
    class InnerFoo : Outer { // HOW is this possible?
        void InnerMethodOne(); 
        // more methods on the derived class
    }
    class InnerBar : Outer { // o_O
        // stuff
    }
