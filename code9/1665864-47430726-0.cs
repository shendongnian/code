    public abstract class Test
    {
        // Won't compile because SomeHelper is internal.
        protected SomeHelper CreateHelper()
        {
            return new SomeHelper();
        }
        public int Func(int x)
        {
            var helper = CreateHelper();
            return helper.DoSomething(x);
        }
    }
    internal class SomeHelper
    {
        public virtual int DoSomething(int x)
        {
            return -x;
        }
    }
