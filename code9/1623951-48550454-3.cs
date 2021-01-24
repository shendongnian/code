    public NewUserWizard_Info_View()
        {
            InitializeComponent();
            Loaded += TriggerValidationOnLoaded;
            FirstNameTextBoxBinding.ValidationRules.Add(new ValidateEmptyOrNull()
            {
                ValidatesOnTargetUpdated = true
            });            
        }
        private void TriggerValidationOnLoaded(object obj, RoutedEventArgs e)
        {
         // This is needed to trigger the validation on first load
            FirstNameTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
        }
