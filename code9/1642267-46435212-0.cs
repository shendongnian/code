    Mapper.Initialize(cfg =>
            {
                cfg.AddProfiles(Assembly.GetExecutingAssembly().GetName().Name);
                cfg.CreateMissingTypeMaps = true;
                cfg.ForAllMaps((typeMap, map) =>
                    map.ForAllMembers(option => option.Condition((source, destination, sourceMember) => sourceMember != null)));
            });
