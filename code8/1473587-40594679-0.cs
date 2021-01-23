    public class DecimalEditTextTargetBinding : MvxConvertingTargetBinding
    {
        protected EditText EditTextControl => Target as EditText;
    
        private IDisposable _subscription;
    
        public DecimalEditTextTargetBinding(EditText target) : base(target)
        {
            if (target == null)
                MvxBindingTrace.Error($"Error - EditText is null in {nameof(DecimalEditTextTargetBinding)}");
        }
    
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
    
            _subscription = EditTextControl.WeakSubscribe<TextView, AfterTextChangedEventArgs>(
                nameof(EditTextControl.AfterTextChanged),
                EditTextOnAfterTextChanged);
        }
    
        private void EditTextOnAfterTextChanged(object sender, AfterTextChangedEventArgs e)
        {
            FireValueChanged(EditTextControl.Text);
        }
    
        protected override void Dispose(bool isDisposing)
        {
            if (isDisposing)
            {
                _subscription?.Dispose();
                _subscription = null;
            }
            base.Dispose(isDisposing);
        }
    }
