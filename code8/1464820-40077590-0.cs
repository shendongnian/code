    public class CustomView : View
    {
        public static readonly BindableProperty MainPageCallbackProperty =
            BindableProperty.Create(nameof(MainPageCallback), typeof(Action<object>), typeof(CustomMap), null);
        public Action<object> MainPageCallback
        {
            get { return (Action<object>)GetValue(MainPageCallbackProperty); }
            set { SetValue(MainPageCallbackProperty, value); }
        }
    }
