    public class RestoreEntityMessage : IMessage
    {
        private string _someString;
        public RetireEntityMessage(string someString)
        {
            _someString = someString;
        }
        public string Body
        {
            get { return _someString + ConfigurationManager.AppSettings["RestoreEntityBody"]; 
        }
        public string Subject
        {
            get { return ConfigurationManager.AppSettings["RestoreEntitySubject"]; }
        }
        public string ToAddress
        {
            get { return ConfigurationManager.AppSettings["EntitryToAddress"]; }
        }
    }
