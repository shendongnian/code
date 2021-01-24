    namespace MyProject
    {
        public class MyColor
        {
            private static Color s_MyGreen = Color.FromRgb(0, 255, 0);
            public static Color MyGreen
            {
                get { return s_MyGreen; }
    
            }
            // ...
        }
    }
