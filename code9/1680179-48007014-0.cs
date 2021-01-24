    public static string NameOfFirstEmptyParam<T>(T parameters) where T: class
        {
            var propertyInfos = typeof(T).GetProperties();
            for (var i = 0; i < propertyInfos.Count(); i++)
            {
                if (string.IsNullOrEmpty(propertyInfos[i].GetMethod.Invoke(parameters, null)?.ToString()))
                    return propertyInfos[i].Name;
            }
            return null;
        }
