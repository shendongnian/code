    public class EntityContractResolver:DefaultContractResolver
        {
            private class PersianDateValueProvider:IValueProvider
            {
                private readonly PropertyInfo _propertyInfo;
    
                public PersianDateValueProvider(PropertyInfo propertyInfo)
                {
                    _propertyInfo = propertyInfo;
                }
    
    
                public void SetValue(object target, object value)
                {
                    try
                    {
                        var date = value as string;
                        if(value==null && _propertyInfo.PropertyType==typeof(DateTime))
                            throw new InvalidDataException();
                        _propertyInfo.SetValue(target,date.ToGregorianDate());
                    }
                    catch (InvalidDataException)
                    {
                        throw new ValidationException(new[]
                        {
                            new ValidationError
                            {
                                ErrorMessage = "Date is not valid",
                                FieldName = _propertyInfo.Name,
                                TypeName = _propertyInfo.DeclaringType.FullName
                            }
                        });
                    }
                }
    
                public object GetValue(object target)
                {
                    if(_propertyInfo.PropertyType.IsNullable() && _propertyInfo.GetValue(target)==null) return null;
                    try
                    {
                        return ((DateTime) _propertyInfo.GetValue(target)).ToPersian();
                    }
                    catch
                    {
                        return string.Empty;
                    }
                    
                }
            }
    
    
            protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
            {
                var list= base.CreateProperties(type, memberSerialization).ToList();
                list.AddRange(type.GetProperties()
                    .Where(pInfo => IsAttributeDefined(pInfo,typeof(AsPersianDateAttribute))&& (pInfo.PropertyType == typeof (DateTime) || pInfo.PropertyType == typeof (DateTime?)))
                    .Select(CreatePersianDateTimeProperty));
                return list;
            }
    
            private JsonProperty CreatePersianDateTimeProperty(PropertyInfo propertyInfo)
            {
                return new JsonProperty
                {
                    PropertyName = "Persian"+propertyInfo.Name ,
                    PropertyType = typeof (string),
                    ValueProvider = new PersianDateValueProvider(propertyInfo),
                    Readable = true,
                    Writable = true
                };
            }
    
            private bool IsAttributeDefined(PropertyInfo propertyInfo,Type attribute)
            {
                var metaDataAttribute = propertyInfo.DeclaringType.GetCustomAttribute<MetadataTypeAttribute>(true);
                var metaDataProperty = metaDataAttribute?.MetadataClassType?.GetProperty(propertyInfo.Name);
                var metaDataHasAttribute = metaDataProperty != null && Attribute.IsDefined(metaDataProperty, attribute);
    
                return metaDataHasAttribute || Attribute.IsDefined(propertyInfo, attribute);
            }
        }
