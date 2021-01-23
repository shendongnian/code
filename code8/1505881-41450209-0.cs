    public class StateListService : IStateListService // The interface to pass around
    {
        IServiceFactory _service_factory;
        const string country = "United States";
        public StateListService(IServiceFactory service_factory)
        {
            _service_factory = service_factory;
            Initialize();
        }
        private void Initialize()
        {
            // I am using WCF services for data
            // Get my WCF client from service factory
            var address_service = _service_factory.CreateClient<IAddressService>();
            using (address_service)
            {
                try
                {
                    // Fetch the data I need
                    var prod_list = address_service.GetStateListByCountry(country);
                    StateList = prod_list;
                }
                catch
                {
                    StateList = new List<AddressPostal>();
                }
            }
        }
        // Access the data from this property when needed
        public List<AddressPostal> StateList { get; private set; }
    }
