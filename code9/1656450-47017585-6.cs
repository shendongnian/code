    public static class Helpers
    {
        public static String Calculate(object value)
        {
            return new DataTable().Compute($"{value}", "").ToString();
        }
    }
