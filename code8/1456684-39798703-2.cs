    byte[] ConvertValue<T>(T value) where T : struct {
        // we have to test for type of T and can use the TypeCode for switch statement
        var typeCode = Type.GetTypeCode(typeof(T));
    
        switch(typeCode) {
            case TypeCode.Int64:
                return BitConverter.GetBytes((long)value);
    
            case TypeCode.Int16:
                return BitConverter.GetBytes((Int16)value);
    
            case TypeCode.UInt32:
                return BitConverter.GetBytes((UInt32)value);
        }
    
        return null;
    }
