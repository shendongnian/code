    .ForMember(destination => destination.Name,
        option => 
        {
            option.Condition(context => 
            {
                var src = context.InstanceCache.First().Value as SourceType;
                return src.Name == default(string);
            });
            option.ResolveUsing(GetDefaultValueAttributeContent);
        });
