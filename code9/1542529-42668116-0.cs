    public partial class CustomCheckbox : UserControl
    {
        public CustomCheckbox()
        {
            InitializeComponent();
        }
        #region IsChecked
        public static readonly DependencyProperty IsCheckedProperty =
            DependencyProperty.Register("IsChecked",
                typeof(bool), typeof(CustomCheckbox),
                new FrameworkPropertyMetadata(
                    false, 
                    FrameworkPropertyMetadataOptions.AffectsRender,
                    IsCheckedPropertyChanged));
        public bool IsChecked
        {
            get { return (bool)GetValue(IsCheckedProperty); }
            set { SetValue(IsCheckedProperty, value); }
        }
        #endregion
        #region IsCheckedPropertyChanged
        private static void IsCheckedPropertyChanged
            (DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            if (source is CustomCheckbox)
            {
                CustomCheckbox control = source as CustomCheckbox;
                bool value = (bool)e.NewValue;
                if (value)
                {
                    control.diagonal1.Visibility = Visibility.Visible;
                    control.diagonal2.Visibility = Visibility.Visible;
                }
                else
                {
                    control.diagonal1.Visibility = Visibility.Hidden;
                    control.diagonal2.Visibility = Visibility.Hidden;
                }
            }
        }
        #endregion
    }
