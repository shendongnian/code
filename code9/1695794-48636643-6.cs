     public class NameValidationParameters : Freezable
    {
        public ListView OriginalTree
        {
            get { return (ListView)this.GetValue(OriginalTreeProperty); }
            set { this.SetValue(OriginalTreeProperty, value); }
        }
        public string OriginalName
        {
            get { return (string)this.GetValue(OriginalNameProperty); }
            set { this.SetValue(OriginalNameProperty, value); }
        }
        public static readonly DependencyProperty OriginalTreeProperty
             = DependencyProperty.Register(nameof(OriginalTree), typeof(ListView),
                 typeof(NameValidationParameters));
        public static readonly DependencyProperty OriginalNameProperty
            = DependencyProperty.Register(nameof(OriginalName), typeof(object),
                typeof(NameValidationParameters));
        protected override Freezable CreateInstanceCore()
        {
            return new NameValidationParameters();
        }
    }
