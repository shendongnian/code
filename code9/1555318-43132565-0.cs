    Mapper.CreateMap<ExpandoObject, SomeBase>()
        .ConstructUsing((ExpandoObject input) => {
            if (input.X == 5)
            {
                return new SomeOne();
            }
            else
            {
                return new SomeBody();
            }
        });
