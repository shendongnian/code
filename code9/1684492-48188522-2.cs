    public class DataReaderConverter<TDto> : ITypeConverter<IDataReader, TDto> where TDto : new
    {
        public TDto Convert(IDataReader source, TDto destination, ResolutionContext context)
        {
            if (destination == null)
            {
                destination = new TDto();
            }
            typeof(TDto).GetProperties()
                .ToList()
                .ForEach(property => property.SetValue(destination, source[property.Name]));
        }
    }
    cfg.CreateMap<IDataReader, MyDto>().ConvertUsing(new DataReaderConverter<MyDto>());
