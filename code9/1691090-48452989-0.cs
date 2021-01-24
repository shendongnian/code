    [assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
    
    namespace MyProject.Android.Renderers
    {
        public class CustomEntryRenderer : EntryRenderer
        {
            public CustomEntryRenderer(Context context) : base(context)
            {
            }
    
            protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
            {
                base.OnElementChanged(e);
                var element = Element as CustomEntry;
                if (element == null || Control == null) return;
    
                Control.InputType = InputTypes.TextVariationUri | InputTypes.TextFlagCapWords;
            }
    
        }
    }
