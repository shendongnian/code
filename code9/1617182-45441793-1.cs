    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomEntry : ContentView
    {
        public CustomEntry()
        {
            InitializeComponent();
            BindingContext = this;
        }
        public string TextValue
        {
            get { return (string)GetValue(TextValueProperty); }
            set{SetValue(TextValueProperty, value);}
        }
        public static BindableProperty TextValueProperty = BindableProperty.Create(nameof(TextValue), typeof(string), typeof(CustomEntry),propertyChanged:OnTextChanged);
        private static void OnTextChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            var entry = bindable as CustomEntry;
            entry?.OnPropertyChanged(nameof(TextIsVisible));
        }
        public bool TextIsVisible => !String.IsNullOrEmpty(TextValue);
    }
