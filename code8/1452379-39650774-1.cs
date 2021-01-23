    public class CollectorFactory
    {
        public static ICollector Create(ICredential credential)
        {
            if(credential.GetType() == typeof(MyCredential))
                return new MyCollector((MyCredential) credential);
            if(credential.GetType() == typeof(OtherCredential ))
                return new OtherCollector((OtherCredential ) credential);
        }
    }
