	// register in code or in xml...
	container.RegisterType<IConverter, XmlConverter>( "xml-Converter" );
	container.RegisterType<IConverter, JsonConverter>( "json-Converter" );
	internal class ConverterConsumer
	{
		public ConverterConsumer( IConverter[] converters )
		{
			_converters = converters.ToDictionary( x => x.FileType, x => x );
		}
		#region private
		private Dictionary<string, IConverter> _converters;
		#endregion
	}
	public interface IConverter
	{
		string FileType { get; }
		void DoConversion( string fileName );
	}
