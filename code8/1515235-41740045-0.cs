    public static bool PropEquals<TProp>(object obj, string propName, TProp valueToTest)
    {
        return EqualityComparer<TProp>.Default.
           Equals(valueToTest, obj.GetType().GetProperty(propName).GetValue(obj));
    }
    ...
    string value = this._predicateFilter.GetValueOrDefault(refName, string.Empty);
    if (!string.IsNullOrEmpty(value))
    {
        predicate.And(c => Assets.Extensions.PropEquals(c, "name", "value to compare"));
    }
