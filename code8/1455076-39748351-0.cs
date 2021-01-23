    System.Windows.Forms.NotifyIcon ni = new System.Windows.Forms.NotifyIcon();
    ni.Icon = new System.Drawing.Icon("D:\\images.ico");
    ni.Visible = true;
    ni.DoubleClick +=delegate(object sender, EventArgs args)
                   {
                      this.Show();
                      this.WindowState = WindowState.Normal;
                   };
