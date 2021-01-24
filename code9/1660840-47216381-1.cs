    var complexData = "Customer.0.OtherAddress".Split('.');
    var type = typeof(Orders);
    PropertyInfo propInfo = null;
    for (var i = 0 ; i < complexData.Length ; i++)
    {
        if (complexData[i] == "0")
        {
            type = type.GetElementType();
        }
        else
        {
            propInfo = type.GetProperty(complexData[i]);
            type = propInfo.PropertyType;
        }
    }
    return propInfo.PropertyType;
