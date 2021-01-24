        private void button_Click(object sender, EventArgs e)
        {
            Process p = new Process
            {
                
                EnableRaisingEvents = true,
                StartInfo =
                {
                    FileName = "NOTEPAD.EXE",
                    Arguments = _path,
                    WindowStyle = ProcessWindowStyle.Maximized,
                    CreateNoWindow = false
                }
            };
            //p.SynchronizingObject = this;
            p.Exited += (a, b) =>
            {
                RefreshTextBox();
                p.Dispose();
            };
            p.Start();
        }
        private void RefreshTextBox()
        {
            using (StreamReader reader = File.OpenText(_appSettingsPath))
            {
                string text = reader.ReadToEnd();
                // Code to parse text looking for value...
                //textBox.Text = text; // reader.Value.ToString();
                threadSafeControlUpdate(textBox, text);
            }
        }
        public delegate void updateUIfunc(Control c, object v);
        public void threadSafeControlUpdate(Control c, object v)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new updateUIfunc(threadSafeControlUpdate), c, v);
                return;
            }
            if (c is TextBox && v is string)
            {
                c.Text = (string)v;
            }
        }
