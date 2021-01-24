    public class SubView : ContentControl
    {
        static SubView()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SubView),
                new FrameworkPropertyMetadata(typeof(SubView)));
        }
    }
    public class MyView : SubView
    {
    }
