    public class ValidationBehavior: Behavior<Entry>
    {
        const string pwRegex = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$";
        static readonly BindablePropertyKey IsInvalidPropertyKey = BindableProperty.CreateReadOnly("IsInvalid", typeof(bool), typeof(EmailValidatorBehavior), false);
        public static readonly BindableProperty IsInvalidProperty = IsInvalidPropertyKey.BindableProperty;
        public bool IsInvalid
        {
            get { return (bool)base.GetValue(IsInvalidProperty); }
            private set { base.SetValue(IsInvalidPropertyKey, value); }
        }
        protected override void OnAttachedTo(Entry bindable)
        {
            bindable.TextChanged += HandleTextChanged;
        }
        void HandleTextChanged(object sender, TextChangedEventArgs e)
        {
            IsInvalid = !(Regex.IsMatch(e.NewTextValue, pwRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)));
            ((Entry)sender).TextColor = IsInvalid ? Color.Red : Color.Default;
        }
        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.TextChanged -= HandleTextChanged;
        }
    }
