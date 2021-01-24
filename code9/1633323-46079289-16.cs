    public class Implementation : IBaseInterface,
                                  IChangeID
    {        
        void IChangeID.SetID(int id) { ID = id; }
        public int ID { get; private set; }
    }
    var obj = new Implementation();
    obj.SetID() // This WILL NOT Compile
