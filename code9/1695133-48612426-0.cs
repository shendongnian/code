    using Android.Content;
    
    using Xamarin.Forms;
    using Xamarin.Forms.Platform.Android;
    
    using CustomDatePicker.Droid;
    
    [assembly: ExportRenderer(typeof(Picker), typeof(DisabledDatePickerRenderer))]
    namespace CustomDatePicker.Droid
    {
        public class DisabledDatePickerRenderer : DatePickerRenderer
        {
            public DisabledDatePickerRenderer(Context context) : base(context)
            {
            }
    
            protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
            {
                base.OnElementPropertyChanged(sender, e);
    
                if (e.PropertyName.Equals(nameof(Element.IsEnabled)) && Control != null)
                {
                    if (Element.IsEnabled)
                    {
                        //Set the text color when the DatePicker is enabled
                        Control.SetTextColor(Android.Graphics.Color.Black);
                    }
                    else
                    {
                        //Set the text color when the DatePicker is disabled
                        Control.SetTextColor(Android.Graphics.Color.Gray);
                    }
                }
            }
        }
    }
