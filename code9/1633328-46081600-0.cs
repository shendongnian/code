    public interface IInterface
    {
        int ID { get; }
    }
    internal class InternalImplementation: IInterface {
        public InternalImplementation(int ID) { this.ID = ID; }
        public int ID { get; set; }
    }
    public class MyImplementationFactoryService {
        public IInterface Create(int ID) {
            return new InternalImplementation(id);
        }
        public IInterface Create(int ID, type|enum createtype) {
            // return type based on typeof or enum
        }
    }
