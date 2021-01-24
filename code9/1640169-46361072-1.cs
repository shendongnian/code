    public class fullScreen
    {
    public class adjustScreen
        {
            public void KeyHandler_F(object sender, KeyEventArgs e, dynamic KVV)
            {
                if (e.Key == Key.F)
                {
                    ToggleWindow(KVV);
                }
            }
            private void ToggleWindow(dynamic KVV)
            {
                switch (KVV.WindowState)
                {
                    case (WindowState.Maximized):
                        {
                            KVV.WindowState = WindowState.Normal;
                            KVV.WindowStyle = WindowStyle.ToolWindow;
                        }
                        break;
                    default:
                        {
                            KVV.WindowState = WindowState.Maximized;
                            KVV.WindowStyle = WindowStyle.None;
                        }
                        break;
                }
            }
        }
    }
