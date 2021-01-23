    public interface IMyGeneric<T>
    {
        void MyGeneric(string stuff);
    }
    public interface IMyGoodGeneric<T>
    {
        void MyGoodMethod1(T entity);
        void MyGoodMethod2(T entity);
    }
    public interface IMyCrazyGeneric<T>
    {
        void MyCrazyMethod1(T entity);
        void MyCrazyMethod2(T entity);
    }
