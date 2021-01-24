    [Pure]
    public static bool IsNullOrDefault<T>(this T? pValue)
    where T : struct {
       return pValue == null || pValue.Value.Equals(default(T));
       // or as suggested in comments (tested)
       return pValue == null || EqualityComparer<T?>.Default.Equals(pValue, default(T));
    }
