    public class MyGiantGeneric<T> : IMyGeneric<T>,
                                     IMyGoodGeneric<T>,
                                     IMyCrazyGeneric<T> where T : IEntity
    {
        private readonly IMyGeneric<T> _myGeneric;
        private readonly IMyGoodGeneric<T> _myGoodGeneric;
        private readonly IMyCrazyGeneric<T> _myCrazyGeneric;
        public MyGiantGeneric(IMyGeneric<T> myGeneric,
                              IMyGoodGeneric<T> myGoodGeneric,
                              IMyGCrazyGeneric<T> myCrazyGeneric)
        {
            _myGeneric = myGeneric;
            _myGoodGeneric = myGoodGeneric;
            _myCrazyGeneric = myCrazyGeneric;
        }
        public void MyGeneric(string stuff)
        {
            _myGeneric.MyGeneric(stuff);
        }
        public void MyGoodMethod1(T entity) 
        {
            _myGoodGeneric.MyGoodMethod1(entity);
        }
        // and so on...
    }    
