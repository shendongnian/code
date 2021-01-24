    public static class ObjectRegister
    {
        //Note the 'where', which constrains T to be something that
        //implements IRegisterable 
        public static T Instantiate<T>() where T:IRegisterable
        {
            T obj = new T();
            StoreReference(obj);
            return obj;
        }
    }
    //Elsewhere, where class 'Thing' implements IRegisterable
    Thing x = ObjectRegister.Instantiate<Thing>();
    //x is now registered
    
    string y = ObjectRegister.Instantiate<string>();
    //Error: string does not implement IRegisterable
