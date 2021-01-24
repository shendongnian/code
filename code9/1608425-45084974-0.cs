    public static class Behaviors
    {
        public static ObservableCollection<string> GetTest(DependencyObject obj) => (ObservableCollection<string>)obj.GetValue(TestProperty);
        public static void SetTest(DependencyObject obj, ObservableCollection<string> value) => obj.SetValue(TestProperty, value);
        public static readonly DependencyProperty TestProperty =
            DependencyProperty.RegisterAttached("Test", typeof(ObservableCollection<string>), typeof(Behaviors), new PropertyMetadata(null, (d, e) =>
            {
                var textBlock = d as TextBlock;
                var collection = e.NewValue as ObservableCollection<string>;
                collection.CollectionChanged += (s, a) => 
                {
                    // put logic here
                    textBlock.Text = ... ;
                };
            }));
    }
