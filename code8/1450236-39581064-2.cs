    public class ObjectPool
    {
        public ObjectPool(Func<ObjectPoolObject> creationMethod)
        {
            ObjectPoolObject objectPoolObject = creationMethod();
            objectPoolObject.m_pool = this;
        }
    }
    public abstract class ObjectPoolObject
    {
        public ObjectPool m_pool;
    }
