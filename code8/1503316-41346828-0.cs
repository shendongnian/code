    public sealed partial class MainPage
    {
        private TextBox _textBox;
        private TextBlock _textBlock;
        public MainPage()
        {
            InitializeComponent();
            Loaded += MainPage_Loaded;
        }
        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            _textBlock = new TextBlock
            {
                Margin = new Thickness(10000, 10000, 0, 0),
            };
            MainGrid.Children.Add(_textBlock);
            _textBox = new TextBox
            {
                Width = _textBlock.ActualWidth + 64, //is for clear button space
                Height = _textBlock.ActualHeight,
            };
            _textBox.TextChanged += _textBox_TextChanged;
            MainGrid.Children.Add(_textBox);
        }
        private void _textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            _textBlock.Text = _textBox.Text;
            _textBox.Width = _textBlock.ActualWidth + 64;
            _textBox.Height = _textBlock.ActualHeight;
        }
    }
