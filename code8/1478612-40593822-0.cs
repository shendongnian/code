            var DNIDynConfig = new MapperConfiguration(cfg => cfg.CreateMissingTypeMaps = true);
            var dniDynMapper = DNIDynConfig.CreateMapper();
            var DNIConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<dynamic, DNI>()
                .ConstructUsing(dyn => new DNI(dni2DBMapper.Map<DNI2>(dyn)))
                .AfterMap((src, dest) =>
                {
                    dniDynMapper.Map(src, dest, typeof(object), typeof(DNI));
                });
            });
