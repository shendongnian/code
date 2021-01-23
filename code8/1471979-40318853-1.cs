        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);
        private void button1_Click(object sender, EventArgs e)
        {
            Excel.Range myRng;
            Excel.Application app = Globals.ThisAddIn.Application;
            string fileName;
            fileName = app.ActiveWorkbook.Name;
            Process[] processes = Process.GetProcessesByName("excel");
            foreach (Process p in processes)
            {
                if (p.MainWindowTitle.Contains(fileName.Substring(fileName.LastIndexOf("/") + 1)))
                {
                    SetForegroundWindow(p.MainWindowHandle);
                }
            }
            this.Visible = false;
            try
            {
                myRng = app.InputBox("Prompt", "Title", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, 8);
            }
            catch
            {
                myRng = null;
            }
            if (myRng != null)
            {
                label1.Text = myRng.Address.ToString();
            }
            this.Visible = true;
            this.Activate();
        }
