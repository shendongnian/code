        private void rtb_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D0 && e.Shift)
            {
                this.txtResponse.SelectionColor = Color.Black;
            }
        }
        private void rtb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '(')
            {
                this.txtResponse.SelectionColor = Color.Red;
            }
        }
