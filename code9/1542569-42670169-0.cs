    using MyAPI;
    
    public class MyWrapper
    {
        private MyAPI _api;
    
        public MyWrapper()
        {
           _api = new MyAPI(); //Especially if you want to do some inits
        }
    
        public void APIMethod()
        {
            _api.APIMethod();
        }
    }
