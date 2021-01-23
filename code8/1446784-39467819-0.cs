    public static readonly DependencyProperty SBItemProperty = DependencyProperty.Register("SBItem", typeof(string), typeof(BAutoComplete), new PropertyMetadata(Changed));
    
        private static void Changed(DependencyObject d, DependencyPropertyChangedEventArgs e) {
          MultiBindingExpression mbe = null;
          try {
            mbe = BindingOperations.GetMultiBindingExpression(d, e.Property);
          } catch { }
          if (mbe != null) {
            foreach (var beb in mbe.BindingExpressions) {
              var bindingExpressionBase = (BindingExpression)beb;
              var di = bindingExpressionBase.DataItem;
              var p = di.GetType().GetProperty(bindingExpressionBase.ResolvedSourcePropertyName);
              var val = p.GetValue(di);
              Console.WriteLine($"Property: {p.Name} Value: {val}");
            }
          } else {
            try {
              var binding = BindingOperations.GetBindingExpression(d, e.Property);
              var di = binding.DataItem;
              var p = di.GetType().GetProperty(binding.ResolvedSourcePropertyName);
              var val = p.GetValue(di);
              Console.WriteLine($"Property: {e.Property.Name} Value: {val}");
            } catch {
              Console.WriteLine("No binding found");
            }
          }
        }
