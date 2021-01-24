    public void MaximizeToMonitor(Form frm, int monitorIndex)
        {
            try
            {
                Screen screen = Screen.AllScreens[monitorIndex];
                if(screen != null)
                {
                    frm.WindowState = FormWindowState.Normal;
                    var workingArea = screen.WorkingArea;
                    frm.Left = workingArea.Left + 10;
                    frm.Top = workingArea.Top + 10;
                    frm.Width = workingArea.Width + 10;
                    frm.Height = workingArea.Height + 10;
                    frm.WindowState = FormWindowState.Maximized;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Monitor does not exists. {Environment.NewLine}{ex.Message}");
            }
        }
