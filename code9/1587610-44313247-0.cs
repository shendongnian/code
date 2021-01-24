        /// <summary>
        /// Utilize functions for both Linq-to-Entities and non-db context
        /// </summary>
        public static class MyCustomResolver
        {
            [DbFunction("Edm", "AddMinutes")]
            public static DateTime? AddMinutes(DateTime? timeValue, int addValue)
            {
                return timeValue?.AddMinutes(addValue);
            }
        }
