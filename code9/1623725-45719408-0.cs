        private void setup_NotifyIcon()
        {
            Thread notifyThread = new Thread(
            delegate ()
            {
                myNotifyIcon = new NotifyIcon();
                setTrayIcon();
                myNotifyIcon.MouseDown += new MouseEventHandler(myNotifyIcon_MouseDown);
                mnuCancel = new MenuItem("Cancel Parsing");
                menu = new ContextMenu();
                mnuCancel.Click += new System.EventHandler(menuItemCancel_Click);
                menu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { mnuCancel });
                myNotifyIcon.ContextMenu = menu;
                myNotifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info; //Shows the info icon so the user doesn't thing there is an error.
                myNotifyIcon.BalloonTipText = "The P6 Parser will minimize to the system tray while working.";
                myNotifyIcon.BalloonTipTitle = "Processing...";
                myNotifyIcon.Visible = true;
                myNotifyIcon.ShowBalloonTip(500);
                myNotifyIcon.Visible = true;
                System.Windows.Forms.Application.Run();
            });
            notifyThread.Start();
            
        }
