    private void opc(object sender, EventArgs e)
    {
        for (int i = 13; i <= 16; i++)
        {
            Control[] buttons = this.Controls.Find(String.Format("button{0}", i), false);
            if (buttons.Length > 0)
            {
                Button btn = (buttons[0] as Button);
                btn.Click += btn_Click;
                btn.Enabled = true; // or false
            }
        }
    }
    void btn_Click(object sender, EventArgs e)
    {
        MessageBox.Show((sender as Button).Name);
    }
