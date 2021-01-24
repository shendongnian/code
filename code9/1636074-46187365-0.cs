    public class JsonTypeConverter<TModel> : TypeConverter
    {
        /* rest of your class ... */
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value is string strValue)
            {
                return JsonConvert.DeserializeObject<TModel>(strValue, new JsonSerializerSettings
                {
                    ContractResolver = new CustomContractResolver(),
                });
            }
            return base.ConvertFrom(context, culture, value);
        }
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string) && value is TModel model)
            {
                return JsonConvert.SerializeObject(model, new JsonSerializerSettings
                {
                    ContractResolver = new CustomContractResolver(),
                });
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }     
    class CustomContractResolver : DefaultContractResolver
    {
        protected override JsonContract CreateContract(Type objectType)
        {
            if (typeof(DataModel).IsAssignableFrom(objectType))
            {
                return this.CreateObjectContract(objectType);
            }
            return base.CreateContract(objectType);
        }
    }
 
                      
