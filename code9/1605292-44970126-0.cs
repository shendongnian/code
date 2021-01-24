     public class ConditionalSourceValueResolver : IValueResolver<Source, Destination, Value[]>
        {
            public Value[] Resolve(Source source, Destination destination, Value[] destMember, ResolutionContext context)
            {
                if (source.Fields == null)
                    return context.Mapper.Map<Value[]>(source.Results);
                else
                    return context.Mapper.Map<Value[]>(source.Fields);
            }
        }
