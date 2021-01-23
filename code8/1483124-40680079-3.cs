        private void CheckControl(Control c)
        {
            if (c is TextBox && c.Visible && string.IsNullOrEmpty(c.Text))
            {
                MessageBox.Show($"TextBox {c.Name} is empty");
            }
        }
       
