    CreateMap<Animal, AnimalDto>()
          .ConstructUsing(animal => {
               switch (animal.AnimalType) {
                   case EAnimalType.Dog:
                       return Mapper.Map<DogDto>(animal);
                   case EAnimalType.Cat:
                       return Mapper.Map<CatDto>(animal);
               }       
           })
          // map members of base class
          .ForMember(dto => dto.Age, o => o.MapFrom(ent => ent.Age));
    
          // handle dispatch to child type mappings
          CreateMap<Animal, DogDto>()
               .ForMember(dto => dto.Age, o => o.Ignore()); // already mapped from base type 
               .ForMember(dto => dto.DogSpecific, o => o.MapFrom(dog => dog.DogSpecific);
          CreateMap<Animal, CatDto>()
               .ForMember(dto => dto.Age, o => o.Ignore()); // already mapped from base type
