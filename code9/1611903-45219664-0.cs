    public class BaseClass<T> where T: Interface
    {
        public virtual bool StartUpdate(T input)
        {
            // return whatever
        }
    }
    public class DerivedClass : BaseClass<ClientClass>
    {
        public override bool StartUpdate(ClientClass input )
        {
            // return whatever
        }
    } 
