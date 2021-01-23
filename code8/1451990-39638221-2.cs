    /// <summary>
    /// Replaces a DBNull value with the default of the type specified
    /// </summary>
    /// <typeparam name="T">Resulting type</typeparam>
    /// <param name="value">Object to check for DBNull</param>
    /// <param name="tryConvert">if true the object will be converted to the target type if possible, otherwise an InvalidCastException is raised</param>
    /// <returns>p_this if it is not DBNull.Value, else default(T)</returns>
    /// <exception cref="InvalidCastException">Thrown if the target type is incorrect and the value could not be converted to it</exception>
    public static T ReplaceDbNullWithDefault<T>(this object value, bool tryConvert = true)
    {
        if (value == System.DBNull.Value || value == null)
            return default(T);
        if (value is T)
            return (T) value;
        if(!tryConvert || !(value is IConvertible))
            throw new InvalidCastException($"Cannot convert {value.GetType()} to {typeof(T)}.");
        return (T)((IConvertible) value).ToType(typeof(T), null);
    }
