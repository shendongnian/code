    [assembly: ExportRenderer(typeof(CustomPicker), typeof(CustomPickerRenderer))]
    
    namespace XamarinPickerDefaultValueTest.UWP
    {
        public class CustomPickerRenderer : PickerRenderer
        {
            protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
            {
                base.OnElementChanged(e);
                var element = Element as CustomPicker;
    
                if (Control != null)
                {
                    Control.PlaceholderText = element.PlaceHolder;
                }
            }
    
        }
    }
