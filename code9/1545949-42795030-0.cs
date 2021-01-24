    public partial class A
    {
        public static partial class Constants
        {
            public const int ConstantA = 1;
        }
    }
    public partial class A
    {
        public static partial class Constants
        {
            public const int ConstantB = 1;
        }
    }
    public class B : A
    {
        static void M()
        {
            int i = Constants.ConstantB;
            int j = Constants.ConstantA;
        }
    }
