        private static Process proc { get; set; }
        private void button1_Click(object sender, EventArgs e)
        {
            if (proc == null || proc.HasExited)
            {
                proc = Process.Start("explorer.exe");
            }
        }
