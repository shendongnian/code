    [assembly: ExportRenderer(typeof(KerningLabel), typeof(KerningLabelRenderer))]
    namespace YourNamespace
    {
        public class KerningLabelRenderer : LabelRenderer
        {
            public KerningLabelRenderer()
            {
                AutoPackage = false;
            }
    
            protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
            {
                base.OnElementChanged(e);
    
                if(e.NewElement != null && Control != null)
                {
                    SetKerning();
                }
            }
    
            private void SetKerning()
            {
                var element = Element as KerningLabel;
                if (element != null && Control != null)
                {
                    Control.Text = element.Text;
                    if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
                    {
                        Control.LetterSpacing = (float)((element.Kerning) / 10.0f);
                    }
                }
            }
    
            protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
            {
                base.OnElementPropertyChanged(sender, e);
    
                if (e.PropertyName == Xaml.KerningLabel.KerningProperty.PropertyName ||
                    e.PropertyName == Xaml.KerningLabel.TextProperty.PropertyName)
                {
                    SetKerning();
                }
            }
        }
