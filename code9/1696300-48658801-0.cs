    public void MaximizeToMonitor(Form frm, int monitorIndex)
        {
            try
            {
                var secondaryScreen = Screen.AllScreens;
                if (secondaryScreen[monitorIndex] != null)
                {
                    frm.WindowState = FormWindowState.Normal;
                    var workingArea = secondaryScreen[monitorIndex].WorkingArea;
                    frm.Left = workingArea.Left + 10;
                    frm.Top = workingArea.Top + 10;
                    frm.Width = workingArea.Width + 10;
                    frm.Height = workingArea.Height + 10;
                    frm.WindowState = FormWindowState.Maximized;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Mintor does not exists. {Environment.NewLine}{ex.Message}");
            }
        }
