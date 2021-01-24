    public class DataAccess
    {
        public void SomeDataLogic1()
        {}
        public void SomeDataLogic2()
        {}
        public void SomeDataLogic3()
        {}
    }
    public class ChildDataAccess : IChildDataAccess
    {
        private readonly DataAccess _dataAccess;
        public ChildDataAccess( DataAccess dataAccess )
        {
            if ( dataAccess == null )
                throw new ArgumentException( nameof( dataAccess ) );
            _dataAccess = dataAccess;
        }
        public void SomeDataLogic1()
        {
            _dataAccess.SomeDataLogic1();
        }
        public void SomeDataLogic3()
        {
            _dataAccess.SomeDataLogic3();
        }
    }
    public interface IChildDataAccess
    {
        void SomeDataLogic1();
        void SomeDataLogic3();
    }
