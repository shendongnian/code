    using Foundation;
    using UIKit;
    using Xamarin.Forms;
    using Xamarin.Forms.Platform.iOS;
    [assembly: ExportRenderer(typeof(MobileProject.MainPage), typeof (com.YourCompany.iOS.KeyboardHookRenderer))]
    namespace com.YourCompany.iOS
    {
    public class KeyboardHookRenderer : PageRenderer
    {
        private string _RecvValue = string.Empty;
        public override bool CanBecomeFirstResponder
        {
            get { return true; }
        }
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);
            string key = string.Empty;
            var selector = new ObjCRuntime.Selector("KeyRecv:");
            UIKeyCommand accelerator1 = UIKeyCommand.Create((NSString)"1", 0, selector);
            AddKeyCommand(accelerator1);
            UIKeyCommand accelerator2 = UIKeyCommand.Create((NSString)"2", 0, selector);
            AddKeyCommand(accelerator2);
            UIKeyCommand accelerator3 = UIKeyCommand.Create((NSString)"3", 0, selector);
            AddKeyCommand(accelerator3);
            ... etc as many as you need or use a loop based on key id...
        }
        [Export("KeyRecv:")]
        public void KeyRecv(UIKeyCommand cmd)
        {
            if (cmd == null)
                return;
            var inputValue = cmd.Input;
            if (inputValue == "\n" || inputValue == "\r")
            {
                ((MobileProject.MainPage) Element)?.HandleHardwareKeyboard(_RecvValue);
                _RecvValue = string.Empty;
            }
            else
            {
                _RecvValue += inputValue;
            }
        }
    }
    }
