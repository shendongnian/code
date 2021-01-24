    private void button1_MouseEnter(object sender, EventArgs e)
    {
       Button btn = sender as Button;
       if(btn !=null)
       {
        btn.UseVisualStyleBackColor = false;
        btn.BackColor = Color.Black;
        btn .ForeColor = Color.White;
       }
    }
