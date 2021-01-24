    public class CultureConverter : Behavior<FrameworkElement>
    {
        private FrameworkElement _HostingControl;
        private DependencyProperty _HostingControlDependencyProperty;
        protected override void OnAttached()
        {
            base.OnAttached();
            _HostingControl = AssociatedObject;
            SetCulture(Translator.CurrentLanguage);
            Translator.LanguageChanged += Translator_LanguageChanged;
        }
        
        protected override void OnDetaching()
        {
            Translator.LanguageChanged -= Translator_LanguageChanged;
            base.OnDetaching();
        }
        
        private void Translator_LanguageChanged(string languageCode)
        {
            if(_HostingControlDependencyProperty != null)
                _HostingControl.GetBindingExpression(_HostingControlDependencyProperty).UpdateTarget();
        }
        private void SetCulture(string languageCode)
        {
            if(_HostingControl is TextBlock)
            {
                _HostingControlDependencyProperty = TextBlock.TextProperty;
            }
            else if (typeof(TextBox) == _HostingControl.GetType())
                _HostingControlDependencyProperty = TextBox.TextProperty;
        }
