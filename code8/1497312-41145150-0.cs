    var autoMapperConfiguration = new MapperConfigurationExpression();
    autoMapperConfiguration
                .CreateMap<IEnumerable<MyRealClass>, UserDetails>()
                .ForMember(dest => dest.SharedPropertyOne, opt => opt.MapFrom(x => x.get(0).SharedPropertyOne)); //you can check if the list is empty
                .ForMember(dest => dest.SharedPropertyTwo, opt => opt.MapFrom(x => x.get(0).SharedPropertyTwo)); //you can check if the list is empty
                .AfterMap((src,dest) => //src is a list type
                     {
                          foreach(MyRealClass myrealclass in src)
                               dest.Users.add(new UserDetails(){
                                               Title = myrealclass.Title,
                                               Forename = myrealclass.Forename,
                                               Surname = myrealclass.Surname
                                                   
                                         });
                     });
