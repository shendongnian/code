    using Xamarin.Forms;
    using Xamarin.Forms.Platform.Android;
     
    [assembly: ExportRenderer(typeof(PlaceholderEditor), typeof(PlaceholderEditorRenderer))]
    namespace EditorWithPlaceholder.Droid.Renderers
    {
        public class PlacehoderEditorRenderer : EditorRenderer
        {
            protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
            {
                base.OnElementChanged(e);
     
                if (Element == null)
                    return;
     
                var element = (PlaceholderEditor) Element;
     
                Control.Hint = element.Placeholder;
                Control.SetHintTextColor(element.PlaceholderColor.ToAndroid());
            }
        }
    }
