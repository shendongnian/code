    static public IEnumerable<T[]> Product<T>(IList<T> items, int repeat) {
        var total = (int)Math.Pow(items.Count, repeat);
        var res = new T[repeat];
        for (var i = 0 ; i != total ; i++) {
            var n = i;
            for (var j = repeat-1 ; j >= 0 ; j--) {
                res[j] = items[n % items.Count];
                n /= items.Count;
            }
            yield return res;
        }
    }
