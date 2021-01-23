    class SomeConsumer<T> where T : ISomeClass
    {
        void SomeMethod(T t)
        {
            ISomeClass obj2 = (ISomeClass) t;
            // execute
            t.Operation();
        }
    }
    
    interface ISomeClass{
        void Operation();
    }
    class SomeClass : ISomeClass {
        public void Operation(){/*execute operation*/}
    }
