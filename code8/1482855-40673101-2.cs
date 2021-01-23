    public class PasswordDigestBehaviour : IEndpointBehavior
    {
        public string Username { get; set; }
    
        public string Password { get; set; }
    
        public PasswordDigestBehaviour(string username, string password)
        {
            Username = username;
            Password = password;
        }
    
        public void AddBindingParameters(ServiceEndpoint endpoint, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
        {
            // do nothing
        }
    
        public void ApplyClientBehavior(ServiceEndpoint endpoint, System.ServiceModel.Dispatcher.ClientRuntime clientRuntime)
        {
            clientRuntime.MessageInspectors.Add(new PasswordDigestMessageInspector(this.Username, this.Password));
        }
    
        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, System.ServiceModel.Dispatcher.EndpointDispatcher endpointDispatcher)
        {
            // do nothing
        }
    
        public void Validate(ServiceEndpoint endpoint)
        {
            // do nothing
        }
    }
