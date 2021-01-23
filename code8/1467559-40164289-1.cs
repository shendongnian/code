        [DebuggerStepThrough]
        public static string SanitizeSQL(this string value)
        {
            return value.Replace("'", "''").Replace("\\", "\\\\");
        }
