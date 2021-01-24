    [assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
    
    namespace MyProject.iOS.Renderers
    {
        public class CustomEntryRenderer : EntryRenderer
        {
            protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
            {
                base.OnElementChanged(e);
                var element = Element as CustomEntry;
                if (Control == null || element == null) return;
    
                Control.AutocapitalizationType = UITextAutocapitalizationType.Words;       
                Control.KeyboardType = UIKeyboardType.Url;
            }
        }
    }
