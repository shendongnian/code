        abstract class MyAbstractClass<T> : MyAbstractClass
        {
            public T GetValue(T parameter)
            {
                Console.WriteLine("Hello from generics");
                return parameter;
            }
    
            public override object GetValue(object parameter)
            {
                return GetValue((T)parameter);
            }
        }
