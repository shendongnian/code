    public class MyViewHelloTargetBinding
        : MvxConvertingTargetBinding
    {
        protected MyView View => Target as MyView;
    
        private bool _subscribed;
    
        public MyViewHelloTargetBinding(MyView target)
            : base(target)
        {
        }
    
        private void HandleHelloChanged(object sender, EventArgs e)
        {
            var view = View;
            if (view == null) return;
    
            FireValueChanged(view.Hello);
        }
    
        public override MvxBindingMode DefaultMode = MvxBindingMode.TwoWay;
    
        public override void SubscribeToEvents()
        {
            var target = View;
            if (target == null)
            {
                MvxBindingTrace.Trace(MvxTraceLevel.Error,
                    "Error - MyView is null in MyViewHelloTargetBinding");
                return;
            }
    
            target.HelloChanged += HandleHelloChanged;
            _subscribed = true;
        }
    
        public override Type TargetType => typeof(string);
    
        protected override void SetValueImpl(object target, object value)
        {
            var view = (MyView)target;
            if (view == null) return;
    
            view.Hellp = (string)value;
        }
    
        protected override void Dispose(bool isDisposing)
        {
            base.Dispose(isDisposing);
            if (isDisposing)
            {
                var target = View;
                if (target != null && _subscribed)
                {
                    target.HelloChanged -= HandleHelloChanged;
                    _subscribed = false;
                }
            }
        }
    }
