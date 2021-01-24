    public sealed partial class NumberEdit : UserControl
    {
        public NumberEdit()
        {
            this.InitializeComponent();
        }
    
        public static readonly DependencyProperty TextInControlProperty =
         DependencyProperty.Register("TextInControl", typeof(string),
                                        typeof(NumberEdit), new PropertyMetadata(null, new PropertyChangedCallback(StringChanged)));
    
        private static void StringChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            int value;
            Int32.TryParse(e.NewValue.ToString(), out value);
            if (0 < value && value < 99)
            {
            }
            else
            {
                var dialog = ServiceLocator.Current.GetInstance<IDialogService>();
                dialog.ShowMessage("Age should be between 1 to 100", "Error mesage");
            }
        }
    
        public string TextInControl
        {
            get { return (string)GetValue(TextInControlProperty); }
            set
            {
                SetValue(TextInControlProperty, value);
            }
        }
    }
