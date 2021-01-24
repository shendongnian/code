    public static int? Sum(this IEnumerable<int?> source) {
    if (source == null) throw Error.ArgumentNull("source");
    int sum = 0;
    checked {
        foreach (int? v in source) {
            if (v != null) sum += v.GetValueOrDefault();
        }
    }
    return sum;
