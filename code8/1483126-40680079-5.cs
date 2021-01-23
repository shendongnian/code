        private void Form1_Load(object sender, EventArgs e)
        {
            CheckControlCollection(this.Controls);
        }
        private void CheckControlCollection(Control.ControlCollection cc)
        {
            foreach (Control c in cc)
                if (c is GroupBox)
                    CheckControlCollection(c.Controls);
                else
                    CheckControl(c);
        }
        private void CheckControl(Control c)
        {
            if (c is TextBox && c.Visible && string.IsNullOrEmpty(c.Text))
                MessageBox.Show($"TextBox {c.Name} is empty");
        }
