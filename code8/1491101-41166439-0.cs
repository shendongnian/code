    bool ValidateMe(object c) {
       var properties = GetProperties(c);
       foreach (var property in properties) {
            var value = property.GetValue(c);
            if (!IsValid((dynamic) value)) {
                return false;
            }
       }
       return true;
    }
    bool IsValid(int value)
    {
        return value != int.MaxValue;
    }
    
    bool IsValid(double value)
    {
        return value != double.MaxValue;
    }
