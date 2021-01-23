    namespace MyWcfProgram.WcfProgram
    {
        public class Client : IClient
        {    
            private readonly ILogic contactLogic;
    
            public Client(ILogic contactLogic)
            {
                if(contactLogic == null)
                {
                    throw new Exception();
                } else
                {
                    this.contactLogic = contactLogic;
                }
            }
    
            // MORE BELOW LEFT OUT
        }
