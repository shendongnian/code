    public class ProductsController : ApiController {
        public ProductsController()
        {
            // As long as _reqState is not changed here
        } 
        private int _reqState = -1;
    
        public object Get(int id) {
            // ... or here
            if (_reqState == -1}  {} //condition #1 - always true
            //DO SOME WORK WITH _reqState
        }
    }
