    public partial class SomeView : UserControl
    {
        ISizeChangedViewModel m_viewModel = null;
        public SomeView()
        {
            InitializeComponent();
            this.DataContextChanged += OnDataContextChanged;
        }
        void OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (m_viewModel != null)
            {
                this.ImageContainer.SizeChanged -= ImageSource_SizeChanged;
            }
            m_viewModel = e.NewValue as ISizeChangedViewModel;
            if (m_viewModel != null)
            {
                this.ImageContainer.SizeChanged += ImageSource_SizeChanged;
            }
        }
        private void ImageSource_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            var newSize = e.NewSize;
            var width = (int)Math.Round(newSize.Width);
            var height = (int)Math.Round(newSize.Height);
            m_viewModel?.SizeChanged(width, height);
        }
    }
