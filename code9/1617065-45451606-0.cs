    public class NativeFlatButtonRenderer : ButtonRenderer
    {
        protected override Android.Widget.Button CreateNativeControl()
        {
            var button = new AppCompatButton(Context, null, Android.Resource.Style.WidgetMaterialButtonBorderlessColored);
            return button;
        }
    }
