     public static class Extensions {
        public static T ThrowIfNull<T>(this T value, string msg) {
            if (value == null) {
                throw new Exception(msg);
            }
            return value;
        }
    }
