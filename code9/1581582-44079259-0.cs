    class MyCoolButton : Button
    {
        public Func<int, int> MyFunc
        {
            get { return (Func<int, int>)GetValue(MyFuncProperty); }
            set { SetValue(MyFuncProperty, value); }
        }
        // Using a DependencyProperty as the backing store for MyFunc.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyFuncProperty =
            DependencyProperty.Register("MyFunc", typeof(Func<int, int>), typeof(MyCoolButton), new PropertyMetadata(null));
    }
