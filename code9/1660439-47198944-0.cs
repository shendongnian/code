    public class BaseData
    { }
    public class AData : BaseData
    { }
    public class BData : BaseData
    { }
    public abstract class BaseWrapper
    {
    }
    public abstract class BaseWrapper<T> : BaseWrapper where T : BaseData
    {
        protected T inner;
        public BaseWrapper(T data)
        {
            inner = data;
        }
        // Additional methods consuming "inner" as BaseData.
        public static BaseWrapper Create(BaseData inner)
        {
           if (inner is AData)
           {
                return new AWrapper((AData)inner);
           }
           if (inner is BData)
           {
                return new BWrapper((BData)inner);
           }
        // And so on....
           return null;
        }
    }
    public class AWrapper : BaseWrapper<AData>
    {
        //Consuming "inner" variable here strongly typed as AData
        public AWrapper(AData data) : base(data)
        {
        }
    }
    public class BWrapper : BaseWrapper<BData>
    {
        //Consuming "inner" variable here strongly typed as BData
        public BWrapper(BData data) : base(data)
        {
        }
    }
