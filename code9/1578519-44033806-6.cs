    public class LocBindingExtension : MarkupExtension {
        private readonly Binding _inner;
        public LocBindingExtension() {
            _inner = new Binding();
        }
        public LocBindingExtension(PropertyPath path) {
            _inner = new Binding();
            this.Path = path;
        }
        public IValueConverter Converter
        {
            get { return _inner.Converter; }
            set { _inner.Converter = value; }
        }
        public PropertyPath Path
        {
            get { return _inner.Path; }
            set { _inner.Path = value; }
        }
        public override object ProvideValue(IServiceProvider serviceProvider) {            
            // Binding is by itself MarkupExtension
            // Call its ProvideValue
            var expression = _inner.ProvideValue(serviceProvider) as BindingExpressionBase;
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
                return expression;
            }
            // return self if there is no binding target (if we use extension inside a template for example)
            return this;  
        }
    }
