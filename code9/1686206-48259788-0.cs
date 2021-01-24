    public class InputUniversalConverter : IsoDateTimeConverter
    {
    	public override bool CanWrite => false;
    
    	public InputUniversalConverter()
    	{
    		DateTimeStyles = DateTimeStyles.AdjustToUniversal;
    	}
    }
    
    config.Formatters.JsonFormatter.SerializerSettings.Converters.Add(new InputUniversalConverter());
