    public class DynamicImageViewAnimatingColorBinding : MvxTargetBinding
    {
        public DynamicImageViewAnimatingColorBinding(DynamicImageView target) : base(target)
        {
        }
        protected DynamicImageView View => Target as DynamicImageView;
        public override MvxBindingMode DefaultMode => MvxBindingMode.OneWay;
        public override Type TargetType => typeof(string);
        public override void SetValue(object value)
        {
            var view = View;
            if (view == null)
                return;
            view.AnimatingColor = (string) value;
        }
    }
