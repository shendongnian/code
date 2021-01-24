            public static IEnumerable<string> SplitAndTrim(this string value, params char[] separators)
            {
                Ensure.Argument.NotNull(value, "source");
                return value.Trim().Split(separators, StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim());
            }
