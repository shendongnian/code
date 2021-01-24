    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    namespace MyProject
    {
        public class IconButton : Button
        {
            public static readonly DependencyProperty ButtonImageProperty = DependencyProperty.Register("ButtonImage", typeof(ImageSource), typeof(IconButton),
                      new FrameworkPropertyMetadata(new BitmapImage(), FrameworkPropertyMetadataOptions.AffectsRender));
            public ImageSource ButtonImage
            {
                get { return (ImageSource)GetValue(ButtonImageProperty); }
                set { SetValue(ButtonImageProperty, value); }
            }
        }
    }
