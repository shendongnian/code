    public class MyRichEditBox : RichEditBox
    {
        protected override void OnKeyDown(KeyRoutedEventArgs e)
        {
            var ctrl = Window.Current.CoreWindow.GetKeyState(VirtualKey.Control);
            if (ctrl.HasFlag(CoreVirtualKeyStates.Down))
            {
                //return; //if you want to totally disable crtl
                if (e.Key == VirtualKey.A)
                {
                    return;
                }
            }
            base.OnKeyDown(e);
        }
    }
