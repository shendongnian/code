        public static readonly DependencyProperty HasErrorsProperty = DependencyProperty.Register("HasErrors", typeof(bool), typeof(CustomContentControl), new PropertyMetadata(false));
        public bool HasErrors
        {
            get { return (bool)GetValue(HasErrorsProperty); }
            set { SetValue(HasErrorsProperty, value); }
        }
        public CustomContentControl()
        {
            InitializeComponent();
            Validation.AddErrorHandler(this, (s, args) => {
                if (args.Action == ValidationErrorEventAction.Added)
                    HasErrors = true;
                else
                    HasErrors = false;
            });  
        }
