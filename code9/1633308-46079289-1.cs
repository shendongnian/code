    public interface IChangeID
    {
        void SetID(int id);
    }
    
    public interface IBaseInterface
    {
        int ID { get; }
    }
    public class Implementation : IBaseInterface,
                                  IChangeID
    {
        private int _id;
        public void SetID(int id) { _id = id; }
        public int ID => _id;
    }
