    public class MyGeneric<T> : IMyGeneric<T> where T : IEntity
    {
        public void MyGeneric(string stuff)
        {
            // implementation
        }
    }
    public class MyGoodGeneric<T> : IMyGoodGeneric<T> where T : IEntity
    {
        public void MyGoodMethod1(T entity) {}
        public void MyGoodMethod2(T entity) {}
    }
    public class MyCrazyGeneric<T> : IMyCrazyGeneric<T> where T : IEntity
    {
        public void MyCrazyMethod1(T entity) {}
        public void MyCrazyMethod2(T entity) {}
    }
