    /// <summary>
    /// Executes a query, returning the data typed as per T
    /// </summary>
    /// <returns>A sequence of data of the supplied type;
    /// if a basic type (int, string, etc) is queried then the data
    /// from the first column in assumed, otherwise an instance is
    /// created per row, and a direct column-name===member-name mapping
    /// is assumed (case insensitive).
    /// </returns>
    public static IEnumerable<T> Query<T>
