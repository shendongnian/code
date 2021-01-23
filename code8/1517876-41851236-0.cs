    public class JobService : IJobService
    {
        private IClientService _clientService;
        private INodeServices _nodeServices;
        //Constructor
        public JobService(IClientService clientService, INodeServices nodeServices)
        {
            _clientService = clientService;
            _nodeServices = nodeServices;
        }
        //Some task to execute
        public async Task SomeTask(Guid subject)
        {
            // Do some job here
            Client client = _clientService.FindUserBySubject(subject);
        }      
    }
