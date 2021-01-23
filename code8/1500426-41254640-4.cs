    public class ExMessage
    {
    	private const int __size = 4;
    	public static ExMessage[] Create(byte[] payload)
    	{
    		return payload
    			.Select((b, i) => new { b, i })
    			  .GroupBy(x => x.i / __size, x => x.b)
    			  .Select(x => new ExMessage(x.ToArray()))
    			  .ToArray();
    	}
        /* rest of class */
    }
