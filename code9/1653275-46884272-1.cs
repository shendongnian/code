    class MyClass<T, U>
        where T : Something
        where U : IAnOperation<Something>
    {
        public U GetAnOperationOfSomething()
        {
            IAnOperation<T> anOperation = GenAnOperation();
            return (U)anOperation;
        }
        private IAnOperation<T> GenAnOperation()
        {
            throw new NotImplementedException();
        }
    }
    public class Something
    { }
    public interface IAnOperation<T>
        where T : Something
    { }
