    public class LocBindingExtension : MarkupExtension {
        public BindingBase Binding { get; set; }
        public override object ProvideValue(IServiceProvider serviceProvider) {
            if (Binding == null)
                return null;
            // Binding is by itself MarkupExtension
            // Call its ProvideValue
            var expression = Binding.ProvideValue(serviceProvider) as BindingExpressionBase;
            if (expression != null) {                
                // if got expression - create weak reference
                // you don't want for this to leak memory by preventing binding from GC
                var wr = new WeakReference<BindingExpressionBase>(expression);
                PropertyChangedEventHandler handler = null;
                handler = (o, e) => {                    
                    if (e.PropertyName == nameof(LocalizeDictionary.Instance.Culture)) {
                        BindingExpressionBase target;
                        // when culture changed and our binding expression is still alive - update target
                        if (wr.TryGetTarget(out target))
                            target.UpdateTarget();
                        else
                            // if dead - unsubsribe
                            LocalizeDictionary.Instance.PropertyChanged -= handler;
                    }
                        
                };
                LocalizeDictionary.Instance.PropertyChanged += handler;
            }
            return expression;
        }
    }
