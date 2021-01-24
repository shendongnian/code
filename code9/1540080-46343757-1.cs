    [assembly: ResolutionGroupName("MyNameSpace.Helpers")]
    [assembly: ExportEffect(typeof(PlatformLineThroughEffect), nameof(PlatformLineThroughEffect))]
    namespace MyNameSpace.iOS.Renderers
    {
    	public class PlatformLineThroughEffect : PlatformEffect
    	{
    		protected override void OnAttached()
    		{
    			SetUnderline(true);
    		}
    
    		protected override void OnDetached()
    		{
    			SetUnderline(false);
    		}
    
    		protected override void OnElementPropertyChanged(System.ComponentModel.PropertyChangedEventArgs args)
    		{
    			base.OnElementPropertyChanged(args);
    
    			if (args.PropertyName == Label.TextProperty.PropertyName ||
    				args.PropertyName == Label.FormattedTextProperty.PropertyName)
    			{
    				SetUnderline(true);
    			}
    		}
    
    		private void SetUnderline(bool underlined)
    		{
    			try
    			{
    				var label = (UILabel)Control;
    				if (label != null)
    				{
    					var text = (NSMutableAttributedString)label.AttributedText;
    					if (text != null)
    					{
    						var range = new NSRange(0, text.Length);
    						if (underlined)
    						{
    							text.AddAttribute(UIStringAttributeKey.StrikethroughStyle,
    								NSNumber.FromInt32((int)NSUnderlineStyle.Single), range);
    						}
    						else
    						{
    							text.RemoveAttribute(UIStringAttributeKey.StrikethroughStyle, range);
    						}
    					}
    				}
    			}
    			catch (Exception ex)
    			{
    				ex.Track();
    			}
    		}
    	}
    }
