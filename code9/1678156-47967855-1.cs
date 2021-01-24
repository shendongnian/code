    // this is in App_Code folder, 
    // you can reference code from main application here, 
    // such as IMessages interface
    public class Messages : IMessages {
        public string CodeNotFound
        {
            get { return "The entered code was not found"; }
        }
    }
