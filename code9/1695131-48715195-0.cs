    namespace MyNamespace
    {
      public static class MyColors
      {
        public const string Blue = "#AABBCC";
      }
      public static class MyColor
      {
        public static Color MyBlue { get { return Color.FromHex(MyColors.Blue); } }
      }
    }
