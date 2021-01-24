    using System;
    using System.Windows.Forms;
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var notifyIcon1 = new NotifyIcon();
            notifyIcon1.Icon = new Form().Icon;
            notifyIcon1.Visible = true;
            var contextMenuStrip1 = new ContextMenuStrip();
            notifyIcon1.ContextMenuStrip = contextMenuStrip1;
            var timer = new System.Timers.Timer();
            timer.Interval = 3000;
            timer.Elapsed += (sender, e) =>  /*Runs in a different thread than UI thread.*/
            {
                if (contextMenuStrip1.InvokeRequired)
                    contextMenuStrip1.Invoke(new Action(() =>
                    {
                        contextMenuStrip1.Items.Add(e.SignalTime.ToString());
                    }));
                else
                    contextMenuStrip1.Items.Add(e.SignalTime.ToString());
            };
            timer.Start();
            Application.Run();
        }
    }
