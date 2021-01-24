        private bool _ShiftWin = false;
        private void frmPlaceholderRectangle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Shift && e.KeyCode == Keys.LWin)
            {
                _ShiftWin = true;
                txtShowName.Text = "Shift+Win Down at " + DateTime.Now.ToString();
            }
        }
        private void frmPlaceholderRectangle_KeyUp(object sender, KeyEventArgs e)
        {
            if (_ShiftWin && e.KeyCode == Keys.Left)
            {
                txtShowName.Text = "Left Key Up at " + DateTime.Now.ToString();
            }
            if (_ShiftWin && e.KeyCode == Keys.LWin)
            {
                txtShowName.Text = "Shift+Win Up at " + DateTime.Now.ToString();
                _ShiftWin = false;
            }
        }
