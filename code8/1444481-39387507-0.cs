    private void btn_MouseEnter(object sender, System.EventArgs e)
        {
            foreach (Button btn in Controls.OfType<Button>())
            {
                if (btn == ((Button)sender))
                {
                    btn.Enabled = true; 
                }
                else
                {
                    btn.Enabled = false;
                }
            }
        }
        private void btn_MouseLeave(object sender, System.EventArgs e)
        {
            foreach (Button btn in Controls.OfType<Button>())
            {
                btn.Enabled = true;
            }
        }
