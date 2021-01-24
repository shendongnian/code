    namespace Namespace1
    {
        using System.ComponentModel;
        using System.Windows.Media;
    
        public static class MyColors
        {
            [TypeConverter(typeof(ColorConverter))]
            public static string COLOR_1 { get; } = "#AABBCC";
        }
    }
