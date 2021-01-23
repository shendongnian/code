    config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<User, UserViewModel>()
                           .ForMember(m => m.UserRolesList, opt => opt.MapFrom(source => source.UserRoles
                             .Where(w => w.UserId == source.Id)
                             .Select(w => w.Role.Name)
                             .ToList()));
                    });
