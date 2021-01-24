    public class AppMapper
    {
        private IMapper _mapper;
        public AppMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Customer, CustomerTO>();
                //& other such mapping
            });
            _mapper = config.CreateMapper();
        }
    public CustomerTO Map(Customer customerEntity)
        {
            var customerTo= _mapper.Map<Customer,CustomerTO>(customerEntity);
            return customerTo;
        }
