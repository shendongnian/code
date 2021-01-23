    Mapper.Initialize(cfg =>
    {
        cfg.CreateMap<Student, RegisterViewModel>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());
    });
                
    Mapper.AssertConfigurationIsValid();
    
    var myAppUser = new ApplicationUser();
    var student = myAppUser as Student;
    var appUserResult = Mapper.Map<RegisterViewModel>(student);
