    Button button = new Button();
    button.Click += (s,e) => { your code; };
    //button.Click += new EventHandler(button_Click);
    container.Controls.Add(button);
    
    //protected void button_Click (object sender, EventArgs e) { }
