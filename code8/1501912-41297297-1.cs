        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (Control c in this.Controls)
            {
                btn = c as Button;
                {
                    if (btn == null)
                        continue;
                   c.MouseWheel += c_MouseWheel;
                  
                 
                }
            }
        }
        private void c_MouseWheel(object sender, MouseEventArgs e)
        {
            ss = sender as Button;
            TabControl tabControl = sender as TabControl;
            int y = ss.Size.Width;
            int x = ss.Size.Height;
            
                if (e.Delta < 0)
                {
                   
                    ss.Size = new Size(y+2, x+2);
                }
                else
                {
                   
                    ss.Size = new Size(y-2, x-2);
                }
