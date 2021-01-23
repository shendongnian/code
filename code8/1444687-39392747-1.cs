            if ((typeof(T).IsEnum))
            {
                var underlyingType = typeof(T).GetEnumUnderlyingType();
                if (underlyingType == typeof(Int32)
                || underlyingType == typeof(Int16)) //etc.
                {
                    try
                    {
                        dynamic value = arg;
                        var result = (Int32)value; // can throw InvalidCast!
                        return result;
                    }
                    catch
                    {
                        throw;
                    }
                }
                else
                {
                    throw new InvalidCastException("Underlying type
                                 is certainly not castable to Int32!");
                }
            }
            else
            {
                throw new InvalidCastException("Not an Enum!");
            }
        }
