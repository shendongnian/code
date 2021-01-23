    interface IObjectPool<in T> where T : ObjectPoolObject
    {
    }
    class ObjectPoolObject
    {
        public IObjectPool<ObjectPoolObject> Pool { get; internal set; }
    }
    class ObjectPool<T> : IObjectPool<T> where T : ObjectPoolObject
    {
        public ObjectPool(Func<T> createObject)
        {
            T obj = createObject();
            obj.Pool = this;
        }
    }
