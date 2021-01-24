    public enum SpaghettiDiameter
    {
        Value1,
        NEEDS_ALL_SAUCE
    }
    class Program
    {
        static void Main(string[] args)
        {
            string MyEnumType = "TestAppCore.SpaghettiDiameter";
            string MyEnumValue = "NEEDS_ALL_SAUCE";
            SpaghettiDiameter result = (SpaghettiDiameter)Enum.Parse(Type.GetType(MyEnumType), MyEnumValue);
        }
    }
