    private void button_Click(object sender, EventArgs e)
    {
        Button button1=Sender as Button;
        if(button1 != null)
        setcolor(this,button1);
    }
    private static void setcolor(Control Container,Button btnFocus)
        {
            btnFocus.BackColor = Color.Red;
            foreach (Control Btn in Container.Controls)
            {
                if (Btn is Button)
                {
                    if (btnFocus != Btn)
                    {
                        Btn.BackColor = Control.DefaultBackColor;
                    }
                }
            }
        }
