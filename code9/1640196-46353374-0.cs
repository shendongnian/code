    public static class Constants
    {
        static Dictionary<double, string> constantNames;
        static Constants()
        {
            Constants.constantNames = new Dictionary<double, string>();
            Constants.constantNames.Add(3.1415926535898, "π");
            Constants.constantNames.Add(2.718281828459, "e");
        }
        public static string ValueOrString(double value)
        {
            if (constantNames.ContainsKey(value))
            {
                return constantNames[value];
            }
            else
            {
                return value.ToString();
            }
        }
    }
