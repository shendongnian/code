    public static class Enumerations
    {
        public static IEnumerable<Enum> GetAllFlags(this Enum values)
        {
            foreach (Enum value in Enum.GetValues(values.GetType()))
            {
                if (values.HasFlag(value))
                {
                    yield return value;
                }
            }
        }
    }
