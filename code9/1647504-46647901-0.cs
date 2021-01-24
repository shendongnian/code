    interface IInterface
    {
        object GetValue(object parameter);
    }
    abstract class MyAbstractClass<T> : IInterface where T : class
    {
        public T GetValue(T parameter)
        {
            // ...
        }
        object IInterface.GetValue(object parameter) => GetValue(parameter as T);
    }
