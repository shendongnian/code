            switch (comparisonType) {
                case StringComparison.CurrentCulture:
                    return CultureInfo.CurrentCulture.CompareInfo.IsPrefix(this, value, CompareOptions.None);
 
                case StringComparison.CurrentCultureIgnoreCase:
                    return CultureInfo.CurrentCulture.CompareInfo.IsPrefix(this, value, CompareOptions.IgnoreCase); 
 
                case StringComparison.InvariantCulture:
                    return CultureInfo.InvariantCulture.CompareInfo.IsPrefix(this, value, CompareOptions.None); 
                case StringComparison.InvariantCultureIgnoreCase:
                    return CultureInfo.InvariantCulture.CompareInfo.IsPrefix(this, value, CompareOptions.IgnoreCase);
 
                case StringComparison.Ordinal:
                    if( this.Length < value.Length) { 
                        return false; 
                    }
                    return (nativeCompareOrdinalEx(this, 0, value, 0, value.Length) == 0); 
                case StringComparison.OrdinalIgnoreCase:
                    if( this.Length < value.Length) {
                        return false; 
                    }
 
                    return (TextInfo.CompareOrdinalIgnoreCaseEx(this, 0, value, 0, value.Length, value.Length) == 0); 
                default: 
                    throw new ArgumentException(Environment.GetResourceString("NotSupported_StringComparison"), "comparisonType");
            }
