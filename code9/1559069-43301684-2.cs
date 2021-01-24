     public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (!(value is IEnumerable<IValidationMessage>))
            {
                return string.Empty;
            }
            var collection = value as IEnumerable<IValidationMessage>;
            if (!collection.Any())
            {
                return string.Empty;
            }
            if (collection.FirstOrDefault() == null)
            {
               return string.Empty;
            }           
            return collection.FirstOrDefault().Message;
        }
