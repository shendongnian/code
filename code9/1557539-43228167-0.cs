    public sealed class CustomAppBarButton : Control
    {
        public CustomAppBarButton()
        {
            this.DefaultStyleKey = typeof(CustomAppBarButton);
        }
    
        public IconElement Icon
        {
            get { return (IconElement)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }
    
        // Using a DependencyProperty as the backing store for Icon.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register("Icon", typeof(IconElement), typeof(CustomAppBarButton), new PropertyMetadata(null));
    }
