    public class DecimalEditTextTargetBinding : MvxConvertingTargetBinding
    {
        private bool _subscribed;
    
        public DecimalEditTextTargetBinding(EditText target) : base(target)
        {
            if (target == null)
                MvxBindingTrace.Error($"Error - EditText is null in {nameof(DecimalEditTextTargetBinding)}");
        }
    
        protected EditText EditTextControl => Target as EditText;
    
        public override Type TargetType => typeof(string);
    
        public override MvxBindingMode DefaultMode => MvxBindingMode.TwoWay;
    
        protected override void SetValueImpl(object target, object value)
        {
            ((TextView)target).Text = (string)value;
            EditTextControl.SetSelection(EditTextControl.Text?.Length ?? 0);
        }
    
        public override void SubscribeToEvents()
        {
            if (EditTextControl == null)
                return;
    
            EditTextControl.AfterTextChanged += EditTextOnAfterTextChanged;
            _subscribed = true;
        }
    
        private void EditTextOnAfterTextChanged(object sender, AfterTextChangedEventArgs e)
        {
            FireValueChanged(EditTextControl.Text);
        }
    
        protected override void Dispose(bool isDisposing)
        {
            if (isDisposing && EditTextControl != null && _subscribed)
            {
                EditTextControl.AfterTextChanged -= EditTextOnAfterTextChanged;
                _subscribed = false;
            }
    
            base.Dispose(isDisposing);
        }
    }
