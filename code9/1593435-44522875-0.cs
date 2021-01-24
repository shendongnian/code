    Mapper.CreateMap<MyEntity , Enum1ViewModel>()
    .ForMember(
        destination => destination.PropA ,
        option => 
        {
            option.Condition(rc => 
            {
                var myViewModel = (Enum1ViewModel)rc.InstanceCache.First().Value;
                return myViewModel.EnumValue == MyEnum.Value1;
            });
            option.MapFrom(source => source.PropA);
        }
    );
