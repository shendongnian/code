    public class OrderIdTypeConverter : TypeConverter
    {
    	private static readonly Regex OrderIdRegex = new Regex("^(.+):(\\d+)$", RegexOptions.Compiled);
    
    	public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
    	{
    		return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
    	}
    
    	public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
    	{
    		var str = value as string;
    		if (str != null)
    		{
    			int orderId;
    			var match = OrderIdRegex.Match(str);
    			if (match.Success && Int32.TryParse(match.Groups[2].Value, out orderId))
    			{
    				return new OrderId(match.Groups[1].Value, orderId);
    			}
    		}
    
    		return base.ConvertFrom(context, culture, value);
    	}
    }
