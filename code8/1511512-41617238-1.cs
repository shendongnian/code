    public class MyThreadSeparatedImage : ThreadSeparatedImage
    {
        public static readonly DependencyProperty ThreadImageSourceProperty =
            DependencyProperty.Register(
                "ThreadImageSource", 
                typeof(ImageSource),
                typeof(MyThreadSeparatedImage),
                new FrameworkPropertyMetadata(null, ThreadImageSourcePropertyChanged));
        private static void ThreadImageSourcePropertyChanged(
            DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            ((ThreadSeparatedImage)obj).Source = (ImageSource)args.NewValue;
        }
        public ImageSource ThreadImageSource
        {
            get { return (ImageSource)element.GetValue(ThreadImageSourceProperty); }
            set { element.SetValue(ThreadImageSourceProperty, imageSource); }
        }
    }
