    public class DataAccess : IChildDataAccess
    {
        public void SomeDataLogic1()
        {}
        public void SomeDataLogic2()
        {}
        public void SomeDataLogic3()
        {}
    }
    public interface IChildDataAccess
    {
        void SomeDataLogic1();
        void SomeDataLogic3();
    }
