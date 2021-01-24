    [assembly: ExportRenderer(typeof(BetterPicker), typeof(BetterPickerRenderer))]
    
    namespace YourNameSpace.iOS
    {
        public class BetterPickerRenderer : PickerRenderer
        {
            protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
            {
                base.OnElementChanged(e);
    
                if (Control != null)
                {
                    Control.TextAlignment = UITextAlignment.Center;
                }
            }
        }
    }
