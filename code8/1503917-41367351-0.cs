    public static class BoolExtensions
        {
            public static bool GetBoolOrDefault(this bool? val, bool defaultval)
            {
                return val.HasValue ? val.Value : defaultval;
            }
        }
