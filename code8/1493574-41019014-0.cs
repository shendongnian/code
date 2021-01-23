    public static void RebootMachine()
        {
            BackgroundWorker worker = new BackgroundWorker();            
            worker.DoWork += (o, ea) =>
            {
                System.Threading.Thread.Sleep(15000);
            };
            worker.RunWorkerCompleted += (o, ea) =>
            {                
                System.Diagnostics.Process.Start("shutdown.exe", "-f -r -t 0");
            };            
            
            worker.RunWorkerAsync();
            DialogResult result = MsgBox.Show("The device will be initialized in 15 seconds",
                "Restarting device", MsgBox.Buttons.RestartNow, MsgBox.Icon.Info, MsgBox.AnimateStyle.FadeIn);
            if (result == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start("shutdown.exe", "-f -r -t 0");    
            }
            
        }
