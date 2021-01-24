    class DynamicBindingBehaviour: Behavior<TextBox>
    {
        public static readonly DependencyProperty DynamicBindingProperty =
        DependencyProperty.Register("DynamicBinding", typeof(Binding), typeof(DynamicBindingBehaviour), new FrameworkPropertyMetadata());
        public Binding DynamicBinding
        {
            get { return (Binding)GetValue(DynamicBindingProperty); }
            set { SetValue(DynamicBindingProperty, value); }
        }
        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.SetBinding(TextBox.TextProperty, DynamicBinding);
        }
    }
