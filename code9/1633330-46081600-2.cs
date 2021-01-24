    public interface IInterface
    {
        int ID { get; }
    }
    internal class InternalImplementation: IInterface {
        public InternalImplementation(int ID) { this.ID = ID; }
        public int ID { get; set; }
    }
    public class MyImplementationFactoryService {
        public IInterface Create() {
            int id = 1 // Or however you get your ID, possibly from a DB query?
            return new InternalImplementation(id);
        }
        public IInterface Create(type|enum createtype) {
            // return type based on typeof or enum
        }
    }
