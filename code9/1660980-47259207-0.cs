    using System;
    using Foundation;
    using UIKit;
    using Xamarin.Forms;
    using Xamarin.Forms.Platform.iOS;
    using KeyCommandsInXamarinForms.iOS;
    
    [assembly: ExportRenderer(typeof(ContentPage), typeof(MyCustomPageRenderer))]
    namespace KeyCommandsInXamarinForms.iOS
    {
        public class MyCustomPageRenderer : PageRenderer
        {
            protected override void OnElementChanged(VisualElementChangedEventArgs e)
            {
                base.OnElementChanged(e);
    
                if (e.OldElement != null || Element == null)
                {
                    return;
                }
    
                //Create your keycommand as you need.
                UIKeyCommand keyCommand1 = UIKeyCommand.Create(new NSString("1"), UIKeyModifierFlags.Command, new ObjCRuntime.Selector("Action"));
                UIKeyCommand keyCommand2 = UIKeyCommand.Create(new NSString("\t"), 0, new ObjCRuntime.Selector("Action"));
                //Add your keycommands
                this.AddKeyCommand(keyCommand1);
                this.AddKeyCommand(keyCommand2);
            }
    
            [Export("Action")]
            private void Excute()
            {
                Console.WriteLine("Your Action!");
            }
    
    
            //Enable viewcontroller to become the first responder, so it is able to respond to the key commands.
            public override bool CanBecomeFirstResponder
            {
                get
                {
                    return true;
                }
            }
        }
    }
