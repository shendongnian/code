    public class A
    {
        public void method1() {
           // 100 lines of code
           insideMethod1();
        }
    
        protected virtual void insideMethod1() { /* some work here */ }
    }
    
    public class B : A
    {
        protected override void insideMethod1() { }
    }
