    cfg.CreateMap<object, object>()
        .ConstructUsing(src => {
             if (src is FooItem) {
                 return Mapper.Map<BarItem>(src);
             }
             // ...
             throw new InvalidOperationException($"Can not map source item of type '{src.GetType().FullName}'.");
         });
