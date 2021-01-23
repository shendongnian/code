        public class ChatEntryViewRenderer : EntryRenderer
    	{
    		protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    		{
    			if (e.PropertyName == VisualElement.IsFocusedProperty.PropertyName)
    			{
    				if (Control != null)
    				{
    					var chatEntryView = this.Element as ChatEntryView;
    					Control.ShouldEndEditing = (UITextField textField) =>
    					{
    						return !chatEntryView.KeepOpen; // KeepOpen is a custom property I added and is set on my ViewModel if I want the Entry Keyboard to be kept open then I just set this to true.
    					};
    				}
    			}
    
    			base.OnElementPropertyChanged(sender, e);
    		}
    	}
