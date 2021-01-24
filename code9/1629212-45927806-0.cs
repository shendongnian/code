    using Xamarin.Forms;
    using MultiBaseCS_Mobile;
    using MultiBaseCS_Mobile.Droid;
    using Xamarin.Forms.Platform.Android;
    using Android.Text;
    using System.ComponentModel;
    using Android.Graphics.Drawables;
    using Android.Graphics;
    
    [assembly: ExportRenderer(typeof(CustomEntryCell), typeof(CustomEntryRenderer))]
    
    namespace MultiBaseCS_Mobile.Droid
    {
        public class CustomEntryRenderer : EntryRenderer
        {
            InsetDrawable originalBackgroundDrawable = null;
            protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
            {
                base.OnElementChanged(e);
                originalBackgroundDrawable = Control.Background as InsetDrawable;
    
                var entry = (CustomEntryCell)Element;    
                if (entry != null)
                {
                    if (!entry.HasUnderline)
                    {
                        Control.SetBackground(null);
                    }
    
                }
            }
    
    
    
            protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
            {
                base.OnElementPropertyChanged(sender, e);
                var entry = (CustomEntryCell)Element;    
                if (e.PropertyName == CustomEntryCell.HasUnderlineProperty.PropertyName)
                {
                    if (!entry.HasUnderline)
                    {
                        Control.SetBackgroundColor(null);
                    }
                    else
                    {
                        // Underline should appear
                        Control.SetBackgroundColor(originalBackgroundDrawable);
                    }
    
    
                }
            }
        }
    }
