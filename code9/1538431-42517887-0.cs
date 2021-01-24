    [Pure]
    public static bool IsNullOrDefault<T>(this T? pValue)
    where T : struct {
       return pValue == null || pValue.Value.Equals(default(T));
    }
