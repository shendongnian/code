    [assembly: ExportRenderer(typeof(BetterPicker), typeof(BetterPickerRenderer))]
    
    namespace MDWS.Droid
    {
        public class BetterPickerRenderer : PickerRenderer
        {
            protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
            {
                base.OnElementChanged(e);
    
                if (Control != null)
                {
                    Control.Gravity = GravityFlags.CenterHorizontal;
                }
            }
        }
    }
