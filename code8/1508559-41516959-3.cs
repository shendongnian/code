    public partial class MyGeneric<T> where T : IEntity
    {
        public void MyGoodMethod1(T entity)
        {
          //does good stuff with the generic..
        }
        public T MyGoodMethod2()
        {
          //does other good stuff with the generic..
        }
    }
