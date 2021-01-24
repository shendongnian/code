    AutoMapper.Mapper.Initialize(cfg =>
                { 
                    cfg.CreateMap<Role, AppRole>();
                });
                Mapper.Configuration.Seal();
                Mapper.AssertConfigurationIsValid();
