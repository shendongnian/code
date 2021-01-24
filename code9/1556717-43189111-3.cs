    public class A<T> : IAOperationInterface
    {
    }
    public class B
    {
        public IAOperationInterface getA()
        {
             return //... some build code.....
        }
    }
