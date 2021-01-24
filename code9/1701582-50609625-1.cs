    using System.Collections.Generic;
    using System.Dynamic;
    namespace ConsoleApp4
    {
        public class CustomDynamic
        {
            ExpandoObject _values;
            public CustomDynamic()
            {
                _values = new ExpandoObject();
            }
            public void AddProperty(string propertyName, object propertyValue)
            {
                var expandoDict = _values as IDictionary<string, object>;
                if (expandoDict.ContainsKey(propertyName))
                    expandoDict[propertyName] = propertyValue;
                else
                    expandoDict.Add(propertyName, propertyValue);
            }
            public string GetString(string propertyName)
            {
                var expandoDict = _values as IDictionary<string, object>;
                if (expandoDict.ContainsKey(propertyName))
                    return (string)expandoDict[propertyName];
                else
                    throw new KeyNotFoundException($"dynamic object did not contain property {propertyName}");
            }
            public int GetInt(string propertyName)
            {
                var expandoDict = _values as IDictionary<string, object>;
                if (expandoDict.ContainsKey(propertyName))
                    return (int)expandoDict[propertyName];
                else
                    throw new KeyNotFoundException($"dynamic object did not contain property {propertyName}");
            }
        }
    }
