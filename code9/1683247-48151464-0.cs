    public static class TextBlockAp {
        public static readonly DependencyProperty SubscriptTextProperty = DependencyProperty.RegisterAttached(
            "SubscriptText", typeof(string), typeof(TextboxAttachedProperty), new PropertyMetadata(OnSubscriptTextPropertyChanged));
    
        public static string GetSubscriptText(DependencyObject obj) {
            return (string)obj.GetValue(SubscriptTextProperty);
        }
    
        public static void SetSubscriptText(DependencyObject obj, string value) {
            obj.SetValue(SubscriptTextProperty, value);
        }
    
        private static void OnSubscriptTextPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            try {
                var value = e.NewValue as string;
                if (String.IsNullOrEmpty(value)) return;
                var textBlock = (TextBlock)d;
    
                var startTag = "<Subscript>";
                var endTag = "</Subscript>";
                var subscript = String.Empty;
                if (value.Contains(startTag) && value.Contains(endTag)) {
                    int index = value.IndexOf(startTag) + startTag.Length;
                    subscript = value.Substring(index, value.IndexOf(endTag) - index);
                }
    
                var text = value.Split(new[] { startTag }, StringSplitOptions.None);
                textBlock.Inlines.Add(text[0]);
                Run run = new Run($" {subscript}") { BaselineAlignment = BaselineAlignment.Subscript, FontSize = 9 };
                textBlock.Inlines.Add(run);
            } catch (Exception ex) {
                if (ExceptionUtilities.UiPolicyException(ex)) throw;
            }
        }
    }
