	private static ModelConverterList modelConverters = new ModelConverterList();
	
	public static void AddModelConverter<T>(IModelConverter<T> converter) where T : IDataCollection
	{
		modelConverters.Add(converter);
	}
