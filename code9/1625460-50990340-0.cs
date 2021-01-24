    public class ExtEntryRenderer : EntryRenderer
    {
        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
                if (Control != null)
                {
                Control.ShouldChangeCharacters += (UITextField textField, NSRange range, string replacementString) =>
                    {
                    if (range.Location + range.Length > ((UITextField)textField).Text.Length)
                            return false;
                        return true;
                    };
                }                          
        }
    }
