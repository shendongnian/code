    YourClassConstructorOrWhatever(){ 
        AutoMapper.Mapper.CreateMap<YourSourceObject, YourDestObject>()
              .ForMember(dest => dest.Elements, opt => opt.ResolveUsing(src =>
              {
                  var result = new List<YourMapObject>();
                  foreach (var element in src.Elements.Take(10))
                  {
                            result.Add(Mapper.Map<YourMapObject>(element));
                  }
                     return result;             
              }));
    }
