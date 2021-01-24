    // bind handler to MouseEnter Event
    this.yourButton1.MouseEnter += new System.EventHandler(this.allButtons_MouseEnter);
    this.yourButton2.MouseEnter += new System.EventHandler(this.allButtons_MouseEnter);
    // bind handler to MouseLeave Event
    this.yourButton1.MouseLeave += new System.EventHandler(this.allButtons_MouseLeave);
    
    this.yourButton2.MouseLeave += new System.EventHandler(this.allButtons_MouseLeave);
    // enter handler
    private void allButtons_MouseEnter(object sender, System.EventArgs e) 
    {
        Button btn = (Button)sender;
        btn.BackColor = Color.Cyan;
        btn.Font = new Font(btn.Font.Name, btn.Font.Size, FontStyle.Bold);
    }
    
    // leave handler
    private void allButtons_MouseLeave(object sender, System.EventArgs e) 
    {
        Button btn = (Button)sender;
        btn.BackColor = Color.DeepPink; // whatever your original color was
        btn.Font = new Font(btn.Font.Name, btn.Font.Size, FontStyle.Regular);
    }
