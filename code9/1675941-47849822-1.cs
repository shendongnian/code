    cfg.CreateMap<GeneralInfo, GeneralInfo>()
    .ForAllMembers(opts =>
        {
            opts.PreCondition((src, context) =>
            {
                // we can do this as you have a mapping in between the same types and no special handling
                // (i.e. destination member is the same as the source property)
                var property = opts.DestinationMember as System.Reflection.PropertyInfo;
                if (property == null) throw new InvalidOperationException();
                var value = property.GetValue(src);
                return value != null;
            });
        }
    );
  
