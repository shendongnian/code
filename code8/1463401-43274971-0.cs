    [assembly: ExportRenderer(typeof(DatePickerRenderer), typeof(SomeDatePickerRenderer))]
    namespace SuperForms.UWP.Renderers
    {
        public class SomeDatePickerRenderer : DatePickerRenderer
        {
            protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.DatePicker> e)
            {
                base.OnElementChanged(e);
                if (Control != null)
                {
                    // TODO: Focus() doesn't open date picker popup on UWP, it's known issue 
                    // on Xamarin.Forms and should be fixed in 2.5. Had to open it manually.
                    var flyout = new DatePickerFlyout() { Placement = FlyoutPlacementMode.Top };
                    flyout.DatePicked += (s, args) =>
                    {
                        Control.Date = args.NewDate;
                    };
                    FlyoutBase.SetAttachedFlyout(Control, flyout);
                }
            }
            protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
            {
                base.OnElementPropertyChanged(sender, e);
            
                if (e.PropertyName == VisualElement.IsFocusedProperty.PropertyName)
                {
                    if (Element.IsFocused)
                    {
                        FlyoutBase.ShowAttachedFlyout(Control);
                    }
                }
            }
        }
    }
