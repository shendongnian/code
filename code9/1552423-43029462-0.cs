    public override int GetHashCode()
    {
        Type type = GetType();
 
        FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
        Object vThis = null;
 
        for (int i = 0; i < fields.Length; i++)
        {
            // Visibility check and consistency check are not necessary.
            Object fieldValue = ((RtFieldInfo)fields[i]).UnsafeGetValue(this);
 
            // The hashcode of an array ignores the contents of the array, so it can produce 
            // different hashcodes for arrays with the same contents.
            // Since we do deep comparisons of arrays in Equals(), this means Equals and GetHashCode will
            // be inconsistent for arrays. Therefore, we ignore hashes of arrays.
            if (fieldValue != null && !fieldValue.GetType().IsArray)
                vThis = fieldValue;
 
            if (vThis != null)
                break;
        }
 
        if (vThis != null)
            return vThis.GetHashCode();
 
        return type.GetHashCode();
    }
