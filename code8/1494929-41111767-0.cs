    [TemplateVisualState(Name = "IndeterminateAutoReverse", GroupName = "CommonStates")]
    public class MyProgressBar : ProgressBar
    {
        static MyProgressBar()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MyProgressBar), new FrameworkPropertyMetadata(typeof(MyProgressBar)));
        }
        public MyProgressBar()
        {
            var isIndeterminateProperty = DependencyPropertyDescriptor.FromProperty(IsIndeterminateProperty, typeof(MyProgressBar));
            isIndeterminateProperty?.AddValueChanged(this, (s,e) => SetIndeterminateState());
        }
        public bool IndeterminateAutoReverse
        {
            get { return (bool)GetValue(IndeterminateAutoReverseProperty); }
            set { SetValue(IndeterminateAutoReverseProperty, value); }
        }
        public static readonly DependencyProperty IndeterminateAutoReverseProperty =
           DependencyProperty.Register(
               "IndeterminateAutoReverse", 
               typeof(bool), 
               typeof(MyProgressBar), 
               new PropertyMetadata(true, (o, e) => (o as MyProgressBar)?.SetIndeterminateState()));
        private void SetIndeterminateState()
        {
            if (!IsIndeterminate)
            {
                return;
            }
            VisualStateManager.GoToState(
                this, 
                IndeterminateAutoReverse ? "IndeterminateAutoReverse" : "Indeterminate", 
                true);
        }
    }
