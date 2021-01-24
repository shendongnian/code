    public static class AutoMapperConfig
	{
		public static IMapperConfigurationExpression Configuration { get; private set; }
		public static IMapper MapperInstance { get; private set; }
		static AutoMapperConfig()
		{
			Mapper.Initialize(cfg =>
			{
				var types = Assembly.GetExecutingAssembly().GetExportedTypes();
				LoadStandardMappings(types, cfg);
				LoadCustomMappings(types, cfg);
				Configuration = cfg;
			});
			MapperInstance = Mapper.Instance;
		}
		private static void LoadStandardMappings(IEnumerable<Type> types, IMapperConfigurationExpression mapperConfiguration)
		{
			var maps = (from t in types
						from i in t.GetInterfaces()
						where i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>) &&
							  !t.IsAbstract &&
							  !t.IsInterface
						select new
						{
							Source = i.GetGenericArguments()[0],
							Destination = t
						}).ToArray();
			foreach (var map in maps)
			{
				mapperConfiguration.CreateMap(map.Source, map.Destination);
				mapperConfiguration.CreateMap(map.Destination, map.Source);
			}
		}
		private static void LoadCustomMappings(IEnumerable<Type> types, IMapperConfigurationExpression mapperConfiguration)
		{
			var maps = (from t in types
						from i in t.GetInterfaces()
						where typeof(IHaveCustomMappings).IsAssignableFrom(t) &&
							  !t.IsAbstract &&
							  !t.IsInterface
						select (IHaveCustomMappings)Activator.CreateInstance(t)).ToArray();
			foreach (var map in maps)
			{
				map.CreateMappings(mapperConfiguration);
			}
		}
	}
