    using System;
    using System.ComponentModel;
    using System.Globalization;
    
    class NumericTypeDescriptionProvider : TypeDescriptionProvider
    {
    	public static void Register()
    	{
    		Type[] types =
    		{
    			typeof(decimal), typeof(double), typeof(float),
    			typeof(int), typeof(long), typeof(short),
    			typeof(uint), typeof(ulong), typeof(ushort),
    		};
    		foreach (var type in types)
    			TypeDescriptor.AddProvider(new NumericTypeDescriptionProvider(type, TypeDescriptor.GetProvider(type)), type);
    	}
    
    	readonly Descriptor descriptor;
    
    	private NumericTypeDescriptionProvider(Type type, TypeDescriptionProvider baseProvider)
    		: base(baseProvider)
    	{
    		descriptor = new Descriptor(type, baseProvider.GetTypeDescriptor(type));
    	}
    
    	public override ICustomTypeDescriptor GetTypeDescriptor(Type objectType, object instance)
    	{
    		return descriptor;
    	}
    
    	class Descriptor : CustomTypeDescriptor
    	{
    		readonly Converter converter;
    		public Descriptor(Type type, ICustomTypeDescriptor baseDescriptor)
    			: base(baseDescriptor)
    		{
    			converter = new Converter(type, baseDescriptor.GetConverter());
    		}
    		public override TypeConverter GetConverter()
    		{
    			return converter;
    		}
    	}
    
    	class Converter : TypeConverter
    	{
    		readonly Type type;
    		readonly TypeConverter baseConverter;
    		public Converter(Type type, TypeConverter baseConverter)
    		{
    			this.type = type;
    			this.baseConverter = baseConverter;
    		}
    		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
    		{
    			return baseConverter.CanConvertTo(context, destinationType);
    		}
    		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
    		{
    			return baseConverter.ConvertTo(context, culture, value, destinationType);
    		}
    		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
    		{
    			return baseConverter.CanConvertFrom(context, sourceType);
    		}
    		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
    		{
    			if (value is string)
    			{
    				try { return Convert.ChangeType(value, type, culture); }
    				catch { }
    			}
    			return baseConverter.ConvertFrom(context, culture, value);
    		}
    	}
    }
