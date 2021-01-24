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
        
        private static StoreReference(IRegisterable obj)
        {
            //Do your storing code here. This doesn't even need to be a method
            //if your reference storing stuff only happens on object creation
        } 
    }
    //Elsewhere, where class 'Thing' implements IRegisterable
    Thing x = ObjectRegister.Instantiate<Thing>();
    //x is now registered. No need to do x = new Thing()
    
    string y = ObjectRegister.Instantiate<string>();
    //Error: string does not implement IRegisterable
