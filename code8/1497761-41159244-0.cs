        private void Form1_Load(object sender, EventArgs e)
        {
            AttachHandler(this, (s, e2) => ResetTimer());
        }
        private void AttachHandler(Control control, EventHandler handler)
        {
            control.Click += handler;
            foreach (Control c in control.Controls)
            {
                AttachHandler(c, handler);
            }
        }
