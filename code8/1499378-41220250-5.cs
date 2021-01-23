    public class ObjectDataUpdate : Behavior<ItemsControl>
        {
            protected override void OnAttached()
            {
                base.OnAttached();
                AssociatedObject.Loaded += (_, __) =>
                 {
                     //Some logics to update Count. I'm setting directly for sample purpose
                     Count = AssociatedObject.Items.Count;
                 };
            }
    
            public int Count
            {
                get { return (int)GetValue(CountProperty); }
                set { SetValue(CountProperty, value); }
            }
    
            // Using a DependencyProperty as the backing store for Count.  This enables animation, styling, binding, etc...
            public static readonly DependencyProperty CountProperty =
                DependencyProperty.Register("Count", typeof(int), typeof(ObjectDataUpdate), new PropertyMetadata(0));
    
        }
