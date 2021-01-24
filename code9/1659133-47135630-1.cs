	public class ModelConverterList : List<IModelConverter<IDataCollection>> { }
	public interface IModelConverter<out T> : IConverter where T : class, IDataCollection { }
	public interface IDataCollection { }
	public interface IConverter { }
	private static ModelConverterList modelConverters = new ModelConverterList();
	
	public static void AddModelConverter<T>(IModelConverter<T> converter) where T : class, IDataCollection
	{
		modelConverters.Add(converter);
	}
