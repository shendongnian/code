     public static bool IsValidApiRequest<T>(this T entity)
            where T : BaseApiRequest
        {
            var attribute = (ValidatorAttribute)Attribute.GetCustomAttribute(typeof(T), typeof(ValidatorAttribute));
            if (attribute != null)
            {
                if (entity == null)
                    return false;
                var validator = attribute.ValidatorType;
                var instance = Activator.CreateInstance(validator);
                MethodInfo method = instance.GetType().GetMethod("Validate", new[] { typeof(T) });
                object result = method.Invoke(instance, new object[] { entity });
                return (bool)result.GetType().GetProperty("IsValid").GetValue(result); ;
            }
            return true;
        }
