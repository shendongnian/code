    public IEnumerable<ConsumerTransfer> GetСonsumers()
    {
    	Mapper.Initialize(cfg =>
    	{
    		cfg.CreateMap<Consumer, ConsumerTransfer>()
    			.ForMember(dto => dto.Id, opt => opt.MapFrom(src => src.Id))
    			.ForMember(dto => dto.Name, opt => opt.MapFrom(src => src.Name))
    			.ForMember(dto => dto.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
    			.ForMember(dto => dto.ContractorTransfer, opt => opt.MapFrom(src => src.Contractors));
    
    		cfg.CreateMap<Contractor, ContractorTransfer>();
    	});
    
    	return Mapper.Map<IEnumerable<ConsumerTransfer>>(Database.Consumers.GetAll());
    }
