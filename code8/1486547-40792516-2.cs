    public class ViewHandler
    {
        public ViewHandler()
        {
            Messenger.Default.Register<RaiseWindowMessage>(this, raiseNextWindow);
        }        
        private void raiseNextWindow(RaiseWindowMessage obj)
        {
            // determine which window to raise and show it
            switch (obj.WindowName)
            {
                case "NextWindow":
                    NextWindow view = new NextWindow();
                    if (obj.ShowAsDialog)
                        view.ShowDialog();
                    else
                        view.Show();
                    break;
                // some other case here...
                default:
                    break;
            }
        }
    }
 
