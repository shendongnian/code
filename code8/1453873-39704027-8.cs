        private void Form1_Load(object sender, EventArgs e)
        {
            System.Diagnostics.Process.GetProcessesByName("notepad").ToList()
                  .ForEach(p => {
                      p.EnableRaisingEvents = true;
                      p.Exited += p_Exited;
                  });
        }
        void p_Exited(object sender, EventArgs e)
        {
            MessageBox.Show("Notepad closed");
        }
