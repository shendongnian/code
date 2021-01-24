    static class Extensions {
        public static string ToFirebirdString(this Guid guid) {
            var raw = BitConverter.ToString(guid.ToByteArray()).Replace("-", "");
            return $"{raw.Substring(0, 8)}-{raw.Substring(8, 4)}-{raw.Substring(12,4)}-{raw.Substring(16, 4)}-{raw.Substring(20)}";
        }
    }
