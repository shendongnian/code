    public void AddExitButtons() {
    	foreach(Form frm in Application.OpenForms) {	
        	if(frm.Name != this.Name) {
        		Button btn = new Button();
    			btn.Name = "exitBtn";
    			btn.Text = "Exit";
    			btn.Location = new Point(100, 100); // Add x and y position to where you need it.
    			frm.Controls.Add(btn);
        	}
        }
    }
