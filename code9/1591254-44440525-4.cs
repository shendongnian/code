        private void btnLogin_Click(object sender, EventArgs e)
        {
            Hide();
            if (pu == null)
            {
                pu = new Form1(label2.Text);
                pu.VisibleChanged += Pu_VisibleChanged;
                pu.FormClosing += Pu_FormClosing;
            }
            pu.Show();
        }
        private void Pu_VisibleChanged(object sender, EventArgs e)
        {
            // Only show the login form if the form1 is NOT visible
            if (!pu.Visible) Show();
        }
        private void Pu_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Set cancel to true to prevent the form from closing, then hide the form instead
            e.Cancel = true;
            pu.Hide();
            this.Show();
        }
    }
