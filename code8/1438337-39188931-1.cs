    public class AdapterClass : ISomethingToSerialize
    {
        public AdapterClass(MyUnchangeableClass instance)
        {
            mInstance = instance;
        }
        MyUnchangeableClass mInstance;
        public object[] GetItemsToSerialize()
        {
            return mInstance.SomeSpecificGetter();
        }
    }
