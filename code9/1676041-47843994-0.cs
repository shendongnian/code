    [assembly: ExportRenderer(typeof(Xamarin.Forms.Button), typeof(CustomButtonRenderer))]
    namespace TestProject.Droid.CustomRenderers
    {
    public class CustomButtonRenderer: ButtonRenderer
    {
        public CustomButtonRenderer(Context context) : base(context)
        {
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement != null)
            {
                return;
            }
            var nativeButton = (Android.Widget.Button)this.Control;
            nativeButton.SetBackgroundColor(Android.Graphics.Color.Gray);
        }
    }
    }
