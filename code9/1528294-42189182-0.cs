    Mapper.Initialize(cfg =>
    {
        cfg.CreateMap<App1.Domain.LoanApplication, App2.Domain.LoanApplication>()
            .ForMember(x => x.Id, opt => opt.Ignore())
    
        cfg.CreateMap<App1.Domain.BusinessBorrower, App2.Domain.BusinessBorrower>()
            .ForMember(x => x.Id, opt => opt.Ignore())
    
        cfg.CreateMap<App1.Domain.LoanApplicationDebt, App2.Domain.LoanApplicationDebt>()
            .ForMember(x => x.Id, opt => opt.Ignore());
    });
