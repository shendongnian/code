    [assembly: ExportRenderer(typeof(KerningLabel), typeof(KerningLabelRenderer))]
    namespace YourNamespace
    {
        public class KerningLabelRenderer : LabelRenderer
        {
            private NSString _kerningAttribureName = new NSString("NSKern");
    
            protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
            {
                base.OnElementChanged(e);
    
                if (e.NewElement != null && Control != null)
                {
                    SetKerning();
                }
            }
    
            private void SetKerning()
            {
                var element = Element as KerningLabel;
                string text = Element.Text;
                if (string.IsNullOrEmpty(text))
                {
                    Control.Text = string.Empty;
                }
                else
                {
                    var attributedString = new NSMutableAttributedString(text);
                    attributedString.AddAttribute(_kerningAttribureName, NSObject.FromObject(element.Kerning), new NSRange(0, text.Length - 1));
                    Control.AttributedText = attributedString;
                }
            }
    
            protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
            {
                base.OnElementPropertyChanged(sender, e);
    
                if (e.PropertyName == Xaml.KerningLabel.KerningProperty.PropertyName ||
                    e.PropertyName == Label.TextProperty.PropertyName ||
                    e.PropertyName == Label.TextColorProperty.PropertyName)
                {
                    SetKerning();
                }
            }
        }
    }
