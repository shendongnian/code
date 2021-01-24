    class TrayManager : IDisposable
    {
        private readonly NotifyIcon _notifyIcon;
        public TrayManager()
        {
            _notifyIcon = new NotifyIcon
            {
                ContextMenu = new ContextMenu(new[]
                {
                    new MenuItem("Exit", ContextMenu_Exit)
                }),
                Icon = Resources.TrayIcon,
                Text = "Initial value",
                Visible = true
            };
        }
        public void Dispose()
        {
            Dispose(true);
        }
        public void SetToolTipText(string text)
        {
            _notifyIcon.Text = text;
        }
        protected virtual void Dispose(bool disposing)
        {
            _notifyIcon.Visible = false;
        }
        private void ContextMenu_Exit(object sender, EventArgs e)
        {
            Application.ExitThread();
        }
        ~TrayManager()
        {
            Dispose(false);
        }
    }
