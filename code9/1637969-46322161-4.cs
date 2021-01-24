        private void TbFullName_LostFocus(object sender, EventArgs e)
        {
            if (tbFullName.Text == "")
            {
                tbFullName.Text = "Full name";
                tbFullName.ForeColor = SystemColors.InactiveCaption;
            }
        }
        private void TbFullName_GotFocus(object sender, EventArgs e)
        {
            if (tbFullName.Text == "Full name")
            {
                tbFullName.Text = "";
                tbFullName.ForeColor = Color.Black;
            }
        }
