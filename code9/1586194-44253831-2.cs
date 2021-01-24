    public abstract class CustomControllerBase<T> : ApiController
    {
        public List<T> GetAll(string filter = null)
        {
            // Common code goes here.
            // At some point you may need some customization based on the actual implementation
            return this.RetrieveRecords(filter);
        }
    
        protected abstract List<T> RetrieveRecords(string filter);
    }
    
    public class Controller1 : CustomControllerBase <C1>
    {
        protected override List<C1> RetrieveRecords (string filter) {
            // Custom logic goes here
        }
    }
    
    public class Controller2 : CustomControllerBase <C2>
    {
        protected override List<C2> RetrieveRecords (string filter) {
            // Custom logic goes here
        }
    }
