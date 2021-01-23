    var notifyIcon = new System.Windows.Forms.NotifyIcon
        {
            Visible = true,
            Icon = System.Drawing.Icon.ExtractAssociatedIcon(Assembly.GetExecutingAssembly().Location),
            Text = Title
        };
        
        notifyIcon.ShowBalloonTip(1, "Hello World", "Description message", System.Windows.Forms.ToolTipIcon.Info);
