    [assembly: ExportRenderer(typeof(CustomTabbedPage), typeof(CustomTabbedPageRenderer))]
    
    namespace App.UWP
    {
        
        public class CustomTabbedPageRenderer : TabbedPageRenderer
        {
            protected override void OnElementChanged(VisualElementChangedEventArgs e)
            {
                base.OnElementChanged(e);
                Control.TitleVisibility = Windows.UI.Xaml.Visibility.Collapsed;
            }
        }
    }
