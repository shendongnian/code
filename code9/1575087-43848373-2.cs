        public static readonly DependencyProperty TestProperty =
          DependencyProperty.Register("Test", typeof(object), typeof(DataSourceView), new PropertyMetadata(TestPropertyChangedCallback
        ));
        private static void TestPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(e.NewValue);
            System.Diagnostics.Debug.WriteLine(e.OldValue);
        }
