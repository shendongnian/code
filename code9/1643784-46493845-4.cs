    [assembly: ExportRenderer(typeof(ExEditor), typeof(ExEditorRenderer))]
    namespace SampleApp.iOS
    {
        public class ExEditorRenderer : EditorRenderer
        {
            protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
            {
                base.OnElementChanged(e);
    			if (Control == null || Element == null)
    				return;
                UpdateTextOnControl();
            }
            protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
            {
                base.OnElementPropertyChanged(sender, e);
                if (e.PropertyName == nameof(ExEditor.FormattedText)
    			    || e.PropertyName == nameof(Editor.FontFamily)
    			    || e.PropertyName == nameof(Editor.FontSize)
    			    || e.PropertyName == nameof(Editor.TextColor)
                    || e.PropertyName == nameof(Editor.BackgroundColor)
    			    || e.PropertyName == nameof(Editor.FontAttributes))
    				{
    					UpdateTextOnControl();
    				}
            }
            void UpdateTextOnControl()
            {
                var caretPos = Control.GetOffsetFromPosition(Control.BeginningOfDocument, Control.SelectedTextRange.Start);
                if (Element is ExEditor formsElement)
                    if (formsElement.FormattedText != null)
                        Control.AttributedText = formsElement.FormattedText.ToAttributed(new Font(), Element.TextColor);
                var newPosition = Control.GetPosition(Control.BeginningOfDocument, offset: caretPos);
                Control.SelectedTextRange = Control.GetTextRange(newPosition, newPosition);
            }
        }
    }
