    var config = 
        new MapperConfiguration(
            cfg =>
            {
                cfg.CreateMap<Class1, Class2>()
                    .AfterMap((src, dest) =>
                    {
                        dest.ClassesAsObjects = src.ClassesAsObjects
                            .Select(x => 
                            {
                                return (x is Class1ChildClass)
                                    ? (object)(new Class2ChildClass { Value = (x as Class1ChildClass).Value }) 
                                    : null;
                            }).ToArray();
                    });
            }
        );
