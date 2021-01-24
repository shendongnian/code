    [assembly: ExportRenderer(typeof(ExEditor), typeof(ExEditorRenderer))]
    namespace SampleApp.Android
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
    			var caretPos = Control.SelectionStart;
                if (Element is ExEditor formsElement)
                    if (formsElement.FormattedText != null)
                        Control.SetText(formsElement.FormattedText.ToAttributed(new Font(), Element.TextColor, Control),
                                        TextView.BufferType.Spannable);
                        
                Control.SetSelection(caretPos);
    		}
    	}
    }
