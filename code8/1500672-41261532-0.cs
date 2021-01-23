    internal static class CommonMapperExtensions
    {
         internal static IMappingExpression<TSource, TDestination> MapCommonFields<TSource, TDestination>(this IMappingExpression<TSource, TDestination> m)
             where TSource : RmsOelEntryInvolvedEntityBaseDto
             where TDestination : AddNewOELEntryInvolvedEntitiesUnlinkedInvolvedPersonUnlinked
         {
             return 
                .ForMember(dest => dest.EffectiveFromTime, opts => opts.MapFrom(src => FormatDateTimeType(src.EffectiveFromTime)))
                .ForMember(dest => dest.EffectiveToTime, opts => opts.MapFrom(src => FormatDateTimeType(src.EffectiveToTime)));                
         }
    }
