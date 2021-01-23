    public void AddExitButtons() {
    	foreach(TagPage tabPge in tabControl1.TabPages) {	
        	Button btn = new Button();
        	btn.Name = "exitBtn";
        	btn.Text = "Exit";
    	    btn.Location = new Point(100, 100); // Add x and y position to where you need it.
            btn.Click += new EventHandler(this.exitBtn_Click);
        	tabPge.Controls.Add(btn);
        }
    }
    public void exitBtn_Click(Object sender, EventArgs e) {
        MessageBox.Show("Clicked!");
    }
