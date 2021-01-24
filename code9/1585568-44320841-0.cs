    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<SourceModel, DestinationModel>().ConvertUsing<ExampleConverter>();
        }
    }
    public class ExampleConverter : ITypeConverter<SourceModel, DestinationModel>
    {
        private readonly ICloudStorage _storage;
        public ExampleCoverter(ICloudStorage storage)
        {
            // injected here
            _storage = storage;
        }
        public DestinationModel Convert(SourceModel source, DestinationModel destination, ResolutionContext context)
        {
            // do conversion stuff
            return new DestinationModel();
        }
    }
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<ICloudStorage, AzureStorage>();
        services.AddAutoMapper();
    }
