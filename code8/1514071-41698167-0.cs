    namespace WpfApplication2
    {
        public class ImageButton : System.Windows.Controls.Button
        {
            public static readonly DependencyProperty DefaultImageProperty =
                 DependencyProperty.Register("DefaultImage", typeof(Uri), typeof(ImageButton));
            public Uri DefaultImage
            {
                get { return (Uri)GetValue(DefaultImageProperty); }
                set { SetValue(DefaultImageProperty, value); }
            }
            public static readonly DependencyProperty PressedImageProperty =
                DependencyProperty.Register("PressedImage", typeof(Uri), typeof(ImageButton));
            public Uri PressedImage
            {
                get { return (Uri)GetValue(PressedImageProperty); }
                set { SetValue(PressedImageProperty, value); }
            }
        }
    }
