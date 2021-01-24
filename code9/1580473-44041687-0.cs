    using System.Reflection;
    ... 
    // T, IEnumerable<T> - let's generalize it a bit
    public List<T> Filter<T>(string propertyName, string filterValue, IEnumerable<T> persons) {
      if (null == persons)
        throw new ArgumentNullException("persons");
      else if (null == propertyName)
        throw new ArgumentNullException("propertyName");
      PropertyInfo info = typeof(T).GetProperty(propertyName);
      if (null == info)
        throw new ArgumentException($"Property {propertyName} hasn't been found.", 
                                     "propertyName");
      // A bit complex, but in general case we have to think of
      //   1. GetValue can be expensive, that's why we ensure it calls just once
      //   2. GetValue as well as filterValue can be null
      return persons
        .Select(item => new {
          value = item,
          prop = info.GetValue(item),
        })
        .Where(item => null == filterValue
           ? item.prop == null
           : item.prop != null && string.Equals(filterValue, item.prop.ToString()))
        .Select(item => item.value)
        .ToList();
    }
