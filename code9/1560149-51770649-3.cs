    public class MyController 
    {
        IServiceToRegister _serviceToRegister;
        public MyController (IServiceToRegister serviceToRegister)
        {
            _serviceToRegister = serviceToRegister;//Then you can use it inside your controller
        }
    }
