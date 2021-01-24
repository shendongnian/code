    public class DemoClass<TBase> where TBase : class
    {
        public void DemoMethod<T>(T target) where T : TBase
        {
            //...
        }
    }
