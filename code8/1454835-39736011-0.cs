    interface I1<T>
    {
    }
    class ActualClass
    {
    }
    class C1 : I1<ActualClass>
    {
        public C1()
        {
            ActualClass class1 = new ActualClass();
        }
    }
    interface IFactory
    {
        I1<T> Create<T>();
    }
    class ConcreteFactory
    {
        public I1<T> Create<T>() where T : I1<T>, new()
        {
            return new T(); 
        }
    }
