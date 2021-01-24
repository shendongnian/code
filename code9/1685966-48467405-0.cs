    Mapper.Initialize(c =>
    {
        c.CreateMap<model, viewmodel>().ReverseMap();
        c.ForAllMaps((p, mc) =>
        {
            Type st = p.SourceType, sct = GetContained(st);
            Type dt = p.DestinationType, dct = GetContained(dt);
            if (sct != null) mc.ConvertUsing(typeof(TCReverse<,>).MakeGenericType(sct, dt));
            if (dct != null) mc.ConvertUsing(typeof(TCForward<,>).MakeGenericType(st, dct));
        });
    });
    Mapper.AssertConfigurationIsValid();
    Mapper.Map<viewmodel>(new model());
    Mapper.Map<model>(new viewmodel());
