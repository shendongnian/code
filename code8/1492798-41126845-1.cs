    private void Tick(object state)
        {
            this.Dispatcher.Invoke(() =>
            {
                 IntPtr window = Interop.GetWindowHandle(this);
                 IntPtr focused = Interop.GetForegroundWindow();
                if (window != focused)
                {
                    Interop.SetForegroundWindow(window);
                }
            });
        }
