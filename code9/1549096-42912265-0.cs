    public System.Windows.Forms.Button creatbtn()
    {
        for (int i = 0; i < 20; i++)
        {
            btn = new System.Windows.Forms.Button();
            this.Controls.Add(btn);
            
            //btn.Top = c * 28
            btn.Top = 28;
    
            //btn.Left = 150
            btn.Left = 150 + (c * (btn.Width + 5));
    
            btn.Text = "button" + this.c.ToString();
            c++;
        }
        return btn;
    }
