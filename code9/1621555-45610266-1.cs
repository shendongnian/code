    public class CustomControl : Control
    {
        static CustomControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomControl),
                new FrameworkPropertyMetadata(typeof(CustomControl)));
        }
        //... + any properties...
    }
