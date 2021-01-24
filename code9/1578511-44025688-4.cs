    public class CultureConverter : Behavior<FrameworkElement>
    {
        private FrameworkElement _HostingControl;
        private DependencyProperty _HostingControlDependencyProperty;
        protected override void OnAttached()
        {
            base.OnAttached();
            _HostingControl = AssociatedObject;
            _InitHostingControl();
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
        private void _InitHostingControl()
        {
            if(_HostingControl is TextBlock)
            {
                _HostingControlDependencyProperty = TextBlock.TextProperty;
            }
            else if (typeof(TextBox) == _HostingControl.GetType())
                _HostingControlDependencyProperty = TextBox.TextProperty;
        }
