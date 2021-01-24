    public static bool HasSingleElement<T>(IEnumerable<T> value)
    {
        using ( var enumerator = value.GetEnumerator() )
        {
            // Try to get first element - return false if that doesn't exist
            if ( !enumerator.MoveNext() )
                return false;
            // Try to get second element - return false if it does exist
            if ( enumerator.MoveNext() )
                return false;
            // exactly one element exists
            return true;
        }
    }
