    internal interface IChangeID
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
        public void SetID(int id) { ID = id; }
        public int ID { get; private set; }
    }
