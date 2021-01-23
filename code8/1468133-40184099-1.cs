        public int CounterValue
        {
          get { return (int)GetValue(CounterValueProperty); }
          set { SetValue(CounterValueProperty, value); }
        }
    
        // Using a DependencyProperty as the backing store for CounterValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CounterValueProperty =
            DependencyProperty.Register("CounterValue", typeof(int), typeof(UserControl1), new PropertyMetadata(0));
    
      }
