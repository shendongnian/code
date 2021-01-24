    public class SessionManager
    {
        private static SessionManager _instance;
       
        static SessionManager() { 
             _instance = new SessionManager();
             _instance.RecoverState();
        }
        public static SessionManager GetInstance()
        {
            return _instance;
        }
        public SessionManager()
        {
            Console.WriteLine($"{nameof(SessionManager)} constructor called");
            // remove RecoverState() call
        }
