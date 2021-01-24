    public static class ExtensionMethods
    {
        public static bool In<T>(this T t, params T[] values)
            => values.Contains(t);
    }
...
            let parcelItem = o.RPU != "Y" && o.DROP_SHIP != "Y" && s.TRUCK_SHIP != "T" && 
                            !o.SKU.In("ABC-123", "XYZ-789", "JKL-456")
