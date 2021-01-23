    public void AddExitButtons() {
    	foreach(Form frm in Application.OpenForms) {	
        	Button btn = new Button();
        	btn.Name = "exitBtn";
        	btn.Text = "Exit";
    	    btn.Location = new Point(100, 100); // Add x and y position to where you need it.
            btn.Click += new EventHandler(this.exitBtn_Click);
        	frm.Controls.Add(btn);
        }
    }
    public void exitBtn_Click(Object sender, EventArgs e) {
        MessageBox.Show("Clicked!");
    }
