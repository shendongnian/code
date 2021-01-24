    public static class MethodExtensions
    {
        public static Result<T> ParameterDefault<T>(this MethodBase m, string paramName)
        {
            ParameterInfo parameter = m.GetParameters()
                .FirstOrDefault(p => p.Name == paramName);
            if (parameter == null)
                throw new ArgumentException($"No parameter with given name '{paramName}' found", nameof(paramName));
            if (parameter.ParameterType != typeof(T))
                throw new ArgumentException($"Parametertype is not '{typeof(T)}' but '{parameter.ParameterType}'");
            if(parameter.HasDefaultValue)
                return new Result<T>((T)parameter.DefaultValue, true);
            else
                return new Result<T>(default(T), false);
        }
    }
