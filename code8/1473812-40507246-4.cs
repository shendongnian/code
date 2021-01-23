    using System;
    using System.Collections.Generic;
    using System.Globalization;
    public static class NumericValueParser
    {
    	static readonly Dictionary<Type, Func<string, CultureInfo, object>> parsers = new Dictionary<Type, Func<string, CultureInfo, object>>
    	{
    		{ typeof(byte), (s, c) => byte.Parse(s, NumberStyles.Any, c) },
    		{ typeof(sbyte), (s, c) => sbyte.Parse(s, NumberStyles.Any, c) },
    		{ typeof(short), (s, c) => short.Parse(s, NumberStyles.Any, c) },
    		{ typeof(ushort), (s, c) => ushort.Parse(s, NumberStyles.Any, c) },
    		{ typeof(int), (s, c) => int.Parse(s, NumberStyles.Any, c) },
    		{ typeof(uint), (s, c) => uint.Parse(s, NumberStyles.Any, c) },
    		{ typeof(long), (s, c) => long.Parse(s, NumberStyles.Any, c) },
    		{ typeof(ulong), (s, c) => ulong.Parse(s, NumberStyles.Any, c) },
    		{ typeof(float), (s, c) => float.Parse(s, NumberStyles.Any, c) },
    		{ typeof(double), (s, c) => double.Parse(s, NumberStyles.Any, c) },
    		{ typeof(decimal), (s, c) => decimal.Parse(s, NumberStyles.Any, c) },
    	};
    
    	public static IEnumerable<Type> Types { get { return parsers.Keys; } }
    
    	public static object Parse(string value, Type type, CultureInfo culture)
    	{
    		return parsers[type](value, culture);
    	}
    }
