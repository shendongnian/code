    using {your_project_namespace}.UWP;
    using Xamarin.Forms;
    using Xamarin.Forms.Platform.UWP;
    [assembly: ExportRenderer(typeof(ScrollView), typeof(ScrollViewCustomRenderer))]
    namespace {your_project_namespace}.UWP
    {
        public class ScrollViewCustomRenderer : ScrollViewRenderer
        {
            protected override void OnElementChanged(ElementChangedEventArgs<ScrollView> e)
            {
                base.OnElementChanged(e);
                if (Control == null)
                    return;
                Control.IsTabStop = true;
            }
        }
    }
