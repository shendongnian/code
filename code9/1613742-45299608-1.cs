    CreateMap<Person, PersonDTO>()
        .ForMember(x => x.Groups, opt => opt.Ignore())
        .ReverseMap()
        .AfterMap((src, dest) => 
        {
            dest.Groups = src.Groups.Select(g => new GroupDTO { Name = g.Name }).ToList()
        });
    
    CreateMap<Group, GroupDTO>()
        .ForMember(x => x.Members, opt => opt.Ignore())
        .ReverseMap()
        .AfterMap((src, dest) => 
        {
            dest.Members = src.Members.Select(p => new PersonDTO { Name = p.Name }).ToList()
        });
