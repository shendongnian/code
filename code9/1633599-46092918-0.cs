    public partial class ValidatedNumberBox : UserControl
    {
        public static readonly DependencyProperty IsValidProperty = DependencyProperty.RegisterAttached(
            nameof(IsValid), typeof(bool), typeof(ValidatedNumberBox), new PropertyMetadata(true));
        // .NET property wrapper
        public bool IsValid
        {
            get { return (bool)GetValue(IsValidProperty); }
            set { SetValue(IsValidProperty, value); }
        }
        public ValidatedNumberBox()
        {
            InitializeComponent();
            IsValid = CheckValidity();
        }
        private void PART_TextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            IsValid = CheckValidity();
            TextChanged?.Invoke(sender, e);
        }
        private bool CheckValidity()
        {
            return !PART_TextBox.Text.Any(char.IsLetter);
        }
    }
