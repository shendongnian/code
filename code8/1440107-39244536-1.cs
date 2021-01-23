    class SomeConsumer<T> where T : ISomeClass
    {
        void SomeMethod(T t)
        {
            ISomeClass obj2 = (ISomeClass) t;
        }
    }
    
    interface ISomeClass{}
    class SomeClass : ISomeClass {}
