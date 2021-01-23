    using ThirdClass;
    public class OtherClass
    {
        public void foo(ThirdClass third)
        {
            third.bar();
        }
        public void foo()
        {
            foo(new ThirdClass());
        }
    }
