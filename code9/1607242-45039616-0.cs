    public class RestoreEntityMessage : IMessage
    {
        private string _myvar;
        public RestoreEntityMessage(string myvar)
        {
            _myvar = myvar;
        }
      
        public string Body
        {
            get { return _myvar + ConfigurationManager.AppSettings["RestoreEntityBody"]; }
        }       
    }
