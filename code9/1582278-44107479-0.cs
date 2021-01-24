    public class CustomMarkupExtension : MarkupExtension
    {
        public BindingBase Binding { get; set; }
        public override object ProvideValue(IServiceProvider serviceProvider) {
            if (Binding == null) return null;
            var result = Binding.ProvideValue(serviceProvider);
            var expression = result as BindingExpressionBase;
            if (expression != null) {
                expression.UpdateTarget();
                return expression;
            }
            // no expression - return self to apply it again later
            return this;            
        }
    }
