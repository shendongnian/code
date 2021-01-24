        public static class Utilities {
            public static bool NotNullAndEquals(this string value, string expected) {
                return value != null && value.Equals(expected);
            }
        }
